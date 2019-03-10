using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace reactivex_net_demo
{
    public class TimeoutCancellation
    {
        public void Run()
        {
            var observable = CreateObservable();

            var cts = new CancellationTokenSource();
            observable
            .Timeout(TimeSpan.FromMilliseconds(100))
            .Subscribe((string i) => Console.WriteLine($"first handler got {i}"), cts.Token);

            Task.Delay(2000).GetAwaiter().GetResult();
            cts.Cancel();
        }

        private IObservable<string> CreateObservable()
        {
            return Observable.Create<string>(async (IObserver<string> observer, CancellationToken cancellationToken) =>
            {
                cancellationToken.Register(() => Console.WriteLine("I'm disposed"));
                Console.WriteLine("I'm started");
                int i = 0;
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(i * 30 + 1, cancellationToken);
                    observer.OnNext($"{i++}");
                }

                Console.WriteLine("I'm finished");
            });
        }
    }
}

