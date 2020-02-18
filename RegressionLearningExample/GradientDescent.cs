using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegressionLearningExample
{
    public class GradientDescent
    {
        private const decimal LIMIT = 0.00000000000000000000001m;

        private readonly IActivationFunction activationFunction;
        private readonly decimal alpha;

        public GradientDescent(IActivationFunction activationFunction, decimal alpha)
        {
            this.activationFunction = activationFunction;
            this.alpha = alpha;
        }

        public decimal[] Train(decimal[][] xs, decimal[] ys)
        {
            if (xs.Length != ys.Length)
            {
                throw new ArgumentException("m is not correct");
            }

            var resultThetas = new decimal[xs[0].Length + 1];

            bool isFirstRun = true;
            bool isMinus = false;
            bool isFinish = false;

            while (!isFinish)
            {
                decimal[] avgDifference = new decimal[xs[0].Length + 1];

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
                else if (isMinus && avgDifference.Average() >= -LIMIT || !isMinus && avgDifference.Average() <= LIMIT)
                {
                    break;
                }

                resultThetas[0] = resultThetas[0] - alpha * avgDifference[0] / xs.Length;

                for (int i = 0; i < xs[0].Length; i++)
                {
                    resultThetas[i + 1] = resultThetas[i + 1] - alpha * avgDifference[i + 1] / xs.Length;
                }
            }

            return resultThetas;
        }
    }
}
