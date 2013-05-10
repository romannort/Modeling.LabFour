using Modeling.LabFour.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour
{
    public class EmitterElement : ElementBase
    {

        private Double lambda;

        
        public EmitterElement(Double lambda)
        {
            this.lambda = lambda;
        }


        public override Boolean IsDone()
        {
            Boolean result = false; ;
            if (currentTime == 0)
            {
                result = true;
                Start();
            }
            return result;
        }

        public void Start()
        {
            currentTime = (Int32)Math.Round(ExponentialGenerator.Next(lambda)) + 1;
        }

    }
}
