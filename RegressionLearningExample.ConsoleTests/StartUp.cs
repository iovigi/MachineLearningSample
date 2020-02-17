namespace RegressionLearningExample.ConsoleTests
{
    using System;

    using RegressionLearningExample;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ExponentalGrowth();
        }

        private static void ExponentalGrowth()
        {
            IActivationFunction activationFunction = new SimpleActivationFunction();
            double alpha = 0.5;

            GradientDescent gradientDescent = new GradientDescent(activationFunction, alpha);

            double[][] rooms = new double[][] { new double[] { 1 },
                new double[] { 2 }, new double[] { 3 }, new double[] { 4 }, new double[] { 5 } };

            double[] prices = new double[] { 100, 200, 300, 400, 500 };

            var thehas = gradientDescent.Train(rooms, prices);

            var sixRoomPrice = activationFunction.Calculate(new double[] { 6 }, thehas);

            Console.WriteLine(sixRoomPrice);
        }
    }
}
