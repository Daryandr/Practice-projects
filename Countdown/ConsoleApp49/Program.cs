using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp49
{
    public interface ISubscriber
    {
        void Display(string eventText);
    }
    public interface ICountDown
    {
        void Subscribe(ISubscriber sub);

        void Unsubscribe(ISubscriber sub);

        void Timer(int delay, string m);
    }

    public class CountDown : ICountDown
    {

        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber sub)
        {
            this._subscribers.Add(sub);
        }

        public void Unsubscribe(ISubscriber sub)
        {
            this._subscribers.Remove(sub);
        }

        public void Timer(int delay, string message)
        {
            if (delay<0)
            {
                throw new ArgumentException("delay is negative");
            }
            Thread.Sleep(delay);
            foreach (var sub in _subscribers)
            {
                sub.Display(message);
            }
        }
    }
    public class Subscriber : ISubscriber
    {
        public string m = "";
        public void Display(string eventText)
        {
            m = eventText;
            if (eventText == null)
            {
                throw new ArgumentNullException("message argument is null");
            }
            Console.WriteLine("Subscriber({0}): Message", eventText);
        }
    }

    public class Subscriber2 : ISubscriber
    {
        public string m = "";
        public void Display(string eventText)
        {
            m = eventText;
            if (eventText == null)
            {
                throw new ArgumentNullException("message argument is null");
            }
            Console.WriteLine("Subscriber2({0}): Message", eventText);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int ms;
            Console.WriteLine("Enter delay in milliseconds:");
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber();
            var secondSubscriber = new Subscriber2();
            while (!int.TryParse(Console.ReadLine(), out ms))
            {
            }
            Timer.Subscribe(firstSubscriber);
            Timer.Subscribe(secondSubscriber);
            Timer.Timer(ms, $"User event after {ms}");
            Timer.Timer(1000, "3 seconds left");
            Timer.Timer(1000, "2 seconds left");
            Timer.Timer(1000, "1 seconds left");
            Timer.Timer(1000, "Cabooom");
        }
    }
}