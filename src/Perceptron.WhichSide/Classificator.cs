using System;
using System.Linq;

namespace Perceptron.WhichSide
{
    public class Classificator
    {
        public void Execute(int[] amostra, int[] trainedWeights)
        {
            //aplicação da separação dos dados linearmente após aprendizado
            var u = amostra.Select((t, k) => trainedWeights[k] * t).Sum();

            var y = LimiarAtivacao(u);

            Console.WriteLine(y > 0 ? "Amostra da classe A >= 0" : "HelloWorld < 0");
        }

        private int LimiarAtivacao(double u)
        {
            return (u >= 0) ? 1 : 0;
        }
    }
}