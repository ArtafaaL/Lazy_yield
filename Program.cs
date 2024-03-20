using System;
using System.Collections.Generic;
using System.Threading;


namespace Lazy_yield
{
    public class Sequences
    {
        public delegate void DisplaySequence(int element);

        public static DisplaySequence displaySequence;
        
        //Первый
        private static IEnumerable<int> Linear()
        {
            var a = 0;

            while (true)
            {
                yield return a;
                a++;
            }
        }

        //Второй
        private static IEnumerable<int> TakeEven(IEnumerable<int> source)
        {
            foreach (var e in source)
            {
                if (e % 2 == 0) yield return e;
            }
        }

        //Третий
        public static void Show()
        {
            Show(TakeEven(Sequences.Linear()));
        }

        private static void Show(IEnumerable<int> source)
        {
            foreach (var e in source)
                displaySequence(e);
        }       
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sequences.displaySequence += (e) => Console.WriteLine(e);
            Sequences.displaySequence += (e) => Thread.Sleep(100);

            Sequences.Show();

        }
    }
}
