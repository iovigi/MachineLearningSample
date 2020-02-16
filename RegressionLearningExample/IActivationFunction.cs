using System;
using System.Collections.Generic;
using System.Text;

namespace RegressionLearningExample
{
    public interface IActivationFunction
    {
        double Calculate(double[] x, double[] theta);
    }
}
