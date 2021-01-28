namespace Perceptron.WhichSide
{
    public class DataStruct
    {
        public DataStruct(double categoryA, double categoryB, double expectedResult)
        {
            CategoryA = categoryA;
            CategoryB = categoryB;
            ExpectedResult = expectedResult;
        }

        public double CategoryA { get; set; }
        public double CategoryB { get; set; }
        public double ExpectedResult { get; set; }
        public double Bias { get => ExpectedResult; }
    }
}