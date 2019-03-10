using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace reactivex_net_demo
{
    public class RaceCondition
    {
        private readonly Subject<int> subject = new Subject<int>();

        public async Task Run()
        {
            var observable = subject.AsObservable();

            subject.OnNext(0);
            var task1 = observable.FirstAsync();
            subject.OnNext(1);
            subject.OnNext(2);

            var result = await task1;
            Console.WriteLine(result);
        }
    }
}

