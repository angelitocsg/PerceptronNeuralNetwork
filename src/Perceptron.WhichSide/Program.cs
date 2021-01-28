using System;
using System.Collections.Generic;

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

            // var learningData = new List<DataStruct>() {
            //     new DataStruct(1, 2, 3),
            //     new DataStruct(1, 3, 3),
            //     new DataStruct(1, 4, 1),

            //     new DataStruct(2, 1, 3),
            //     new DataStruct(2, 3, 2),
            //     new DataStruct(2, 4, 3),

            //     new DataStruct(3, 1, 3),
            //     new DataStruct(3, 2, 2),
            //     new DataStruct(3, 4, 3),

            //     new DataStruct(4, 1, 1),
            //     new DataStruct(4, 2, 3),
            //     new DataStruct(4, 3, 3),
            // };

            // var learningData = new List<DataStruct>() {
            //     new DataStruct(1, 2, 1),
            //     new DataStruct(1, 3, 1),
            //     new DataStruct(1, 4, 1),

            //     new DataStruct(2, 1, 1),
            //     new DataStruct(2, 3, 2),
            //     new DataStruct(2, 4, 1),

            //     new DataStruct(3, 1, 1),
            //     new DataStruct(3, 2, 2),
            //     new DataStruct(3, 4, 1),

            //     new DataStruct(4, 1, 1),
            //     new DataStruct(4, 2, 1),
            //     new DataStruct(4, 3, 1),
            // };

            var learningData = new List<DataStruct>() {
                new DataStruct(0, 0, 0),
                new DataStruct(0, 1, 0),
                new DataStruct(0, 2, 0),

                new DataStruct(1, 0, 0),
                new DataStruct(1, 1, 1),
                new DataStruct(1, 2, 0),

                new DataStruct(2, 0, 1),
                new DataStruct(2, 1, 0),
                new DataStruct(2, 2, 0),

                new DataStruct(3, 0, 1),
                new DataStruct(3, 1, 1),
                new DataStruct(3, 2, 1),
            };

            var training = new Training(learningData, 1, 500000);

            Console.WriteLine("Weights before training...");
            Console.WriteLine("{0}, {1}, {2}", training.Weight.CategoryA, training.Weight.CategoryB, training.Weight.ExpectedResult);
            Console.WriteLine("\n");

            training.Execute();

            Console.WriteLine("Weights after training...");
            Console.WriteLine("{0}, {1}, {2}", training.Weight.CategoryA, training.Weight.CategoryB, training.Weight.ExpectedResult);
            Console.WriteLine("\n");


            Console.WriteLine("===============================================");
            Console.WriteLine("Training finished.");
            Console.WriteLine("===============================================");



            //dados de entrada para rede treinada, 0 e 0 resulta em 0 (tabela and) -1 corresponde ao BIAS

            int[] amostra1 = { 0, 1, -1 }; // 0 e 1 -> 0 Classe B
            int[] amostra2 = { 1, 0, -1 }; // 1 e 0 -> 0 Classe B
            int[] amostra3 = { 0, 0, -1 }; // 0 e 0 -> 0 Classe B
            int[] amostra4 = { 1, 1, -1 }; // 1 e 1 -> 1 Classe A


            // ClassificarAmostra(amostra1);
            // ClassificarAmostra(amostra2);
            // ClassificarAmostra(amostra3);
            // ClassificarAmostra(amostra4);

            Console.ReadKey();
        }
    }
}
