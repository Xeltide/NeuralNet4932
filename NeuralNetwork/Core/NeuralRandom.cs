using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Core
{
    class NeuralRandom
    {

        private Random random;
        private static NeuralRandom instance;
        public static NeuralRandom Instance {
            get {
                if (instance == null)
                {
                    instance = new NeuralRandom();
                }
                return instance;
            }
        }

        private NeuralRandom()
        {
            random = new Random();
        }

        public double GetRandom(double mean, double stdDev)
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        public int GetRandom()
        {
            return random.Next(0, 10);
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerable)
        {
            List<T> shuffled = new List<T>(enumerable);
            int n = shuffled.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = shuffled[k];
                shuffled[k] = shuffled[n];
                shuffled[n] = value;
            }
            return shuffled;
        }
    }
}
