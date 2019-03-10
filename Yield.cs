using System;
using System.Collections.Generic;

namespace reactivex_net_demo
{
    public class Yield
    {
        public void Run()
        {
            foreach (var i in GetSequence())
            {
                Console.WriteLine($"Got an element {i}");
            }
        }

        private IEnumerable<string> GetSequence()
        {
            while (true)
            {
                Console.WriteLine("Press next key");
                var key = Console.ReadKey();
                yield return $"{key.KeyChar}";
            }
        }
    }
}
