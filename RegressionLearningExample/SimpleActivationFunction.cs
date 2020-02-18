namespace RegressionLearningExample
{
    using System;

    public class SimpleActivationFunction : IActivationFunction
    {
        public decimal Calculate(decimal[] xs, decimal[] thetas)
        {
            if (thetas.Length != xs.Length + 1)
            {
                throw new ArgumentException("Invalid params");
            }

            var result = thetas[0];

            for (int i = 0; i < xs.Length; i++)
            {
                result += thetas[i + 1] * xs[i];
            }

            return result;
        }
    }
}
