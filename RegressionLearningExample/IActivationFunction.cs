using System;
using System.Collections.Generic;
using System.Text;

namespace RegressionLearningExample
{
    public interface IActivationFunction
    {
        decimal Calculate(decimal[] x, decimal[] theta);
    }
}
