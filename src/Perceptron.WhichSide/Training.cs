using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Perceptron.WhichSide
{
    public class Training
    {
        private double _net;

        private List<DataStruct> _learningData { get; }
        private double _learningRate;
        private int _epochCounter;
        private int _epoch;
        private bool _trained;

        public DataStruct Weight { get; }

        public Training(List<DataStruct> learningData, double learningRate = 0.01, int epoch = 10)
        {
            _learningData = learningData;
            _learningRate = learningRate;
            _epoch = epoch;
            _epochCounter = 0;

            Weight = new DataStruct(0, 0, 0);
        }

        public void Execute()
        {
            try
            {
                _trained = true;

                do
                {
                    Run();
                    _epochCounter++;
                }
                while (!_trained && _epochCounter < _epoch);

                if (!_trained && _epochCounter >= _epoch)
                    Console.WriteLine("Training not complete with {0} epoch.", _epoch);

                _epochCounter = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Run()
        {
            Console.WriteLine(">>> Epoch training {0}", _epochCounter + 1);
            Console.WriteLine("{0}, {1}, {2}", Weight.CategoryA, Weight.CategoryB, Weight.ExpectedResult);

            foreach (var data in _learningData)
            {
                var outputFromNet = NetCalculate(data.CategoryA, data.CategoryB);

                if (outputFromNet != data.ExpectedResult)
                {
                    UpdateWeight(data, outputFromNet);
                    _trained = false;
                }
            }
        }

        private int NetCalculate(double categoryA, double categoryB)
        {
            _net = (categoryA * Weight.CategoryA) + (categoryB * Weight.CategoryB) + ((-1) * Weight.Bias);
            return (_net >= 0) ? 1 : 0;
        }

        private void UpdateWeight(DataStruct data, int outputFromNet)
        {
            var calculatedError = data.ExpectedResult - outputFromNet;
            Weight.CategoryA = Weight.CategoryA + (_learningRate * calculatedError * data.CategoryA);
            Weight.CategoryB = Weight.CategoryB + (_learningRate * calculatedError * data.CategoryB);
            Weight.ExpectedResult = Weight.ExpectedResult + (_learningRate * calculatedError * (-1));
        }
    }
}