namespace Core.Infrastructure
{
    using System.Net;

    using Autofac;

    using CommonDomain.Persistence;

    using Core.InvitationPhase;
    using Core.InvitationPhase.Handlers;
    using Core.SetupPhase;
    using Core.SetupPhase.Handlers;

    using EventStore.ClientAPI;

    using MemBus;
    using MemBus.Configurators;

    using Raven.Client;
    using Raven.Client.Document;

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
                        .Apply<IoCSupport>(s => s.SetAdapter(new AutofacAdaptor(context)).SetHandlerInterface(typeof(IObserve<>)))
                        .Construct();
                }).As<IBus>();

            builder.Register(x =>
            {
                var store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "Risk" };
                store.Initialize();
                return store;
            }).As<IDocumentStore>().SingleInstance();

            builder.Register(x => x.Resolve<IDocumentStore>().OpenSession())
                .As<IDocumentSession>()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IObserve<>).Assembly).AsClosedTypesOf(typeof(IObserve<>));

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

            return builder.Build();
        }
    }
}
