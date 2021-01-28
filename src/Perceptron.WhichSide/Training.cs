using System;
using System.Threading;

namespace Perceptron.WhichSide
{
    public class Training
    {
        private double _learningRate;
        private double[,] _data;
        private double[] _weights;
        private int _epoch;
        private int _epochCounter;

        public Training(double[,] data, double[] weigths, double learningRate = 0.25, int epoch = 10)
        {
            _data = data;
            _weights = weigths;
            _learningRate = learningRate;
            _epoch = epoch;
        }

        public void Execute()
        {
            _epochCounter = 0;

            while (_epochCounter < _epoch)
            {
                Console.Write("Epoch {0}", (_epochCounter + 1).ToString().PadLeft(3));

                for (int d = 0; d < _data.GetLength(0); d++)
                {
                    var errorRate = NetCalculate(d);

                    if (errorRate == 0)
                        continue;

                    UpdateWeight(d, errorRate);

                    Thread.Sleep(1);
                }
                _epochCounter++;
            }
        }

        private int NetCalculate(int d)
        {
            var _output = 0.0;

            for (int w = 0; w < _weights.Length; w++)
                _output += _weights[w] * _data[d, w];

            return Activation(_output, _data[d, _data.GetLength(1) - 1]);
        }

        public int Activation(double output, double expected)
        {
            if (output >= 0 && expected == 0) return -1;
            if (output < 0 && expected == 1) return 1;
            return 0;
        }

        private int _epochPrint = -1;
        private void UpdateWeight(int d, int errorRate)
        {
            for (int w = 0; w < _weights.Length; w++)
            {
                _weights[w] = _weights[w] + (_learningRate * errorRate * _data[d, w]);
                var sign = _weights[w] > 0.01 ? "+" : "";

                if (_epochPrint != _epochCounter)
                    Console.Write($"{sign}{sign}{sign}{sign}{_weights[w].ToString("F2")}".PadLeft(12));
            }

            if (_epochPrint != _epochCounter)
            {
                _epochPrint = _epochCounter;
                Console.WriteLine();
            }
        }
    }
}