namespace Console
{
    using System.Net;
    using System.Reflection;

    using Autofac;

    using CommonDomain.Persistence;

    using Core.Infrastructure;
    using Core.InvitationPhase;
    using Core.InvitationPhase.Handlers;
    using Core.SetupPhase;
    using Core.SetupPhase.Handlers;

    using EventStore.ClientAPI;

    using MemBus;
    using MemBus.Configurators;

    using MongoDB.Driver;

    using IBus = MemBus.IBus;

    public class AutofacSetup
    {
        public static ILifetimeScope Build()
        {
            var builder = new ContainerBuilder();

            builder.Register(c =>
                {
                    var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
                    connection.Connect();
                    return connection;
                }).As<IEventStoreConnection>().SingleInstance();

            builder.Register(c =>
                {
                    var context = c.Resolve<IComponentContext>();
                    return BusSetup.StartWith<Conservative>()
                        .Apply<IoCSupport>(s => s.SetAdapter(new AutofacAdaptor(context)).SetHandlerInterface(typeof(IConsume<>)))
                        .Construct();
                }).As<IBus>();

            builder.Register(x =>
            {
                var client = new MongoClient("mongodb://localhost");
                return client.GetServer();
            }).As<MongoServer>().SingleInstance();

            builder.Register(x => x.Resolve<MongoServer>().GetDatabase("Risk"))
                .As<MongoDatabase>()
                .InstancePerDependency();



            builder.RegisterAssemblyTypes(typeof(IConsume<>).Assembly, Assembly.GetExecutingAssembly()).AsClosedTypesOf(typeof(IConsume<>));

            builder.RegisterType<GetEventStoreRepository>().As<IRepository>();

            builder.RegisterType<AcceptInvitationHandler>().As<ICommandHandler<AcceptInvitation>>();
            builder.RegisterType<CreateLobbyHandler>().As<ICommandHandler<CreateLobby>>();
            builder.RegisterType<InvitePlayerHandler>().As<ICommandHandler<InvitePlayer>>();
            builder.RegisterType<LeaveLobbyHandler>().As<ICommandHandler<LeaveLobby>>();
            builder.RegisterType<StartGameHandler>().As<ICommandHandler<StartGame>>();

            builder.RegisterType<StartGameSetupHandler>().As<ICommandHandler<StartGameSetup>>();
            builder.RegisterType<PlaceInfantryUnitHandler>().As<ICommandHandler<PlaceInfantryUnit>>();

            builder.RegisterType<AutofacCommandHandlerResolver>().As<ICommandHandlerResolver>();

            builder.RegisterType<CommandDispatcher>().AsSelf();

            var container = builder.Build();

            return container;
        }
    }
}
