//namespace Core.Facts.Infrastructure
//{
//    using System.Linq;

//    using Core.Infrastructure;

//    using Xunit;
//    using Xunit.Should;

//    public class TopicFacts
//    {
//        [Fact]
//        public void When_gets_raised_and_event_gets_added_to_list()
//        {
//            var topic = new TestableTopic();
//            topic.TestMethod();

//            topic.EventFired.ShouldBeTrue();
//            topic.Events.Count.ShouldBe(1);
//            var @event = topic.Events.Last();
//            @event.ShouldBeInstanceOf<TestEvent>();
//        }

//        private class TestableTopic : Topic
//        {
//            public bool EventFired { get; private set; }

//            public void TestMethod()
//            {
//                this.Raise(new TestEvent());
//            }

//            private void When(TestEvent @event)
//            {
//                this.EventFired = true;
//            }
//        }

//        private class TestEvent
//        {
//        }
//    }
//}
