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
            decimal alpha = 0.01m;

            GradientDescent gradientDescent = new GradientDescent(activationFunction, alpha);

            decimal[][] rooms = new decimal[][] {new decimal[] { 0 }, new decimal[] { 1 },
                new decimal[] { 2 }, new decimal[] { 3 }, new decimal[] { 4 }, new decimal[] { 5 },
                new decimal[] { 6 }, new decimal[] { 7 }, new decimal[] { 8 }, new decimal[] { 9 } };

            decimal[] prices = new decimal[] { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900 };

            var thehas = gradientDescent.Train(rooms, prices);

            var sixRoomPrice = activationFunction.Calculate(new decimal[] { 6 }, thehas);

            Console.WriteLine(sixRoomPrice);
        }
    }
}
