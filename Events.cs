using System;

namespace reactivex_net_demo
{
    public class Events
    {
        public void Run()
        {
            Action<int> action = i => { Console.WriteLine($"got number {i}"); };
            Action<int> action2 = i => { Console.WriteLine($"second handler got number {i}"); };
            SendNumber += action;
            SendNumber += action2;
            SendNumber(1);
            SendNumber(2);
            SendNumber -= action;
            SendNumber -= action2;
        }

        private Action<int> SendNumber = i => { };
    }
}
