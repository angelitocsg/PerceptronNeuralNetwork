using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Perceptron.WhichSide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("===============================================");
            Console.WriteLine("Start training...");
            Console.WriteLine("===============================================");

            var data = new Grandchildren();

            data.Weights.ToList().ForEach(it => Console.Write("{0} ", it));
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");

            Thread.Sleep(2000);

            var training = new Training(data.Data, data.Weights, 0.5, 100);

            training.Execute();

            Console.WriteLine("-----------------------------------------------");
            var order = data.Weights.Select((it, d) => new { Id = d, Weigth = it }).OrderByDescending(it => it.Weigth);

            foreach (var it in order)
            {
                Console.WriteLine($"ID: {it.Id} => {it.Weigth.ToString("F2")}");
            }
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("===============================================");
            Console.WriteLine("Training finished.");
            Console.WriteLine("===============================================");

            Console.ReadKey();
        }
    }
}
