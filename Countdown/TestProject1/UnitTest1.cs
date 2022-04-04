using NUnit.Framework;
using ConsoleApp49;
using System;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestSub()
        {
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber();
            Timer.Subscribe(firstSubscriber);
            Timer.Timer(2000, "Caboom");
            Assert.AreEqual("Caboom",firstSubscriber.m);
        }
        [Test]
        public void TestSub2()
        {
            var Timer = new CountDown();
            var secondSubscriber = new Subscriber2();
            Timer.Subscribe(secondSubscriber);
            Timer.Timer(2000, "Caboom");
            Assert.AreEqual("Caboom", secondSubscriber.m);
        }
        [Test]
        public void TestUnsub()
        {
            var Timer = new CountDown();
            var subscriber = new Subscriber();
            Timer.Subscribe(subscriber);
            Timer.Unsubscribe(subscriber);
            Timer.Timer(2000, "Caboom");
            Assert.AreEqual("", subscriber.m);
        }
        [Test]
        public void CatchNullMesExc()
        {
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber();
            Timer.Subscribe(firstSubscriber);
            Assert.Throws<ArgumentNullException>(() => Timer.Timer(2000, null));
        }
        [Test]
        public void CatchNegDelExc()
        {
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber();
            Timer.Subscribe(firstSubscriber);
            Assert.Throws<ArgumentException>(() => Timer.Timer(-2000, "Caboom"));
        }
        [Test]
        public void TestSeveralSubs()
        {
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber();
            var secondSubscriber = new Subscriber();
            Timer.Subscribe(firstSubscriber);
            Timer.Subscribe(secondSubscriber);
            Timer.Timer(2000, "Caboom");
            string[] m = new string[] { firstSubscriber.m, secondSubscriber.m };
            Assert.AreEqual(new string[]{ "Caboom","Caboom"}, m);
        }
        [Test]
        public void TestNolSubs()
        {
            var Timer = new CountDown();
            Timer.Timer(2000, "Caboom");
        }
    }
}