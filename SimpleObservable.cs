using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace reactivex_net_demo
{
    public class SimpleObservable
    {
        public void Run()
        {
            var observable = CreateObservable();

            Console.WriteLine("1st sub");
            var sub1 = observable
            .Subscribe(i => Console.WriteLine($"first handler got {i}"));

            Console.WriteLine("2nd sub");
            var sub2 = observable
            .Subscribe(i => Console.WriteLine($"second handler got {i}"));

            sub1.Dispose();
            sub2.Dispose();
        }

        private IObservable<string> CreateObservable()
        {
            return Observable.Create<string>((IObserver<string> observer) =>
            {
                Console.WriteLine("I'm started");
                int i = 0;
                while (i++ < 3)
                {

                    observer.OnNext($"{i}");
                }

                return Disposable.Empty;
            });
        }
    }
}

