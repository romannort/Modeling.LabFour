using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour.Generators
{
    public static class ExponentialGenerator
    {
        static Random rand = new Random();

        
        public static Double Next(Double lambda)
        {
            Double divLambda = -1 / lambda;
            Double result = Math.Log(rand.NextDouble()) * divLambda;
            return result;
        }
    }
}
