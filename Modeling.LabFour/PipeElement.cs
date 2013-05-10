using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour
{
    class PipeElement : ElementBase
    {

        private Int32 processingTime;

        public PipeElement(Int32 processingTime)
        {
            this.processingTime = processingTime;
            currentTime = -1;
        }

        public void TakeRequest()
        {
            currentTime = processingTime;
            this.SetBusy();
        }


        public override Boolean IsDone()
        {
            Boolean result = false; ;
            if (currentTime == 0)
            {
                result = true;
                currentTime--; // ?
            }
            return result;
        }
    }
}
