using System;
using System.Threading.Tasks;

namespace reactivex_net_demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var events = new Events();
            // events.Run();

            // var yield = new Yield();
            // yield.Run();

            // var simpleobservable = new SimpleObservable();
            // simpleobservable.Run();

            // var timeoutCancellation = new TimeoutCancellation();
            // timeoutCancellation.Run();

            // var tasks = new Tasks();
            // await tasks.Run();

            var race = new RaceCondition();
            await race.Run();


            Console.WriteLine("Finished Main, waiting 3 seconds before exit");
            await Task.Delay(3000);
        }
    }
}
