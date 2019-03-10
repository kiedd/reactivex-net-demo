using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace reactivex_net_demo
{
    public class Tasks
    {
        public async Task Run()
        {
            var cts = new CancellationTokenSource();
            var task = CreateTask(cts.Token);

            Console.WriteLine("1st sub");
            var sub1 = task
                .ToObservable()
                .Subscribe(i => Console.WriteLine($"first handler got {i}"));

            task.Start();
            await task;
            sub1.Dispose();
        }

        private Task<string> CreateTask(CancellationToken cancellationToken)
        {
            return new Task<string>(() =>
            {
                Console.WriteLine("I'm started");
                Task.Delay(300, cancellationToken).GetAwaiter().GetResult();
                Console.WriteLine("I'm finished");
                return "result";
            });
        }

        private IObservable<int> CreateObservable()
        {
            return Observable.Create<int>(async (IObserver<int> observer, CancellationToken cancellationToken) =>
            {
                cancellationToken.Register(() => Console.WriteLine("I'm disposed"));
                Console.WriteLine("I'm started");
                int i = 0;
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(i * 30 + 1, cancellationToken);
                    observer.OnNext(i++);
                }

                Console.WriteLine("I'm finished");
            });
        }
    }
}

