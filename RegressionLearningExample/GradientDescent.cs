using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegressionLearningExample
{
    public class GradientDescent
    {
        private readonly IActivationFunction activationFunction;
        private readonly double alpha;

        public GradientDescent(IActivationFunction activationFunction, double alpha)
        {
            this.activationFunction = activationFunction;
            this.alpha = alpha;
        }

        public double[] Train(double[][] xs, double[] ys)
        {
            if (xs.Length != ys.Length)
            {
                throw new ArgumentException("m is not correct");
            }

            var resultThetas = new double[xs[0].Length + 1];
            bool isFirstRun = true;
            bool isMinus = false;
            bool isFinish = false;

            while (!isFinish)
            {
                double[] avgDifference = new double[xs[0].Length + 1];

                for (int i = 0; i < xs.Length; i++)
                {
                    var hypothesis = this.activationFunction.Calculate(xs[i], resultThetas);

                    avgDifference[0] = hypothesis - ys[i];

                    for (int j = 0; j < xs[i].Length; j++)
                    {
                        avgDifference[j + 1] = (hypothesis - ys[i]) * xs[i][j];
                    }
                }

                if (isFirstRun)
                {
                    if (avgDifference[0] == 0)
                    {
                        break;
                    }

                    if (avgDifference[0] < 0)
                    {
                        isMinus = true;
                    }

                    isFirstRun = false;
                }
                else if (isMinus && avgDifference.Average() >= -0.00000001 || !isMinus && avgDifference.Average() <= 0.00000001)
                {
                    break;
                }

                resultThetas[0] = resultThetas[0] - alpha * avgDifference[0] / xs.Length;

                for (int i = 0; i < xs[0].Length; i++)
                {
                    resultThetas[i + 1] = resultThetas[i + 1] - alpha * avgDifference[i] / xs.Length;
                }
            }

            return resultThetas;
        }
    }
}
