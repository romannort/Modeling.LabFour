using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour
{
    public abstract class ElementBase
    {

        private static ICollection<ElementBase> instances = new List<ElementBase>();

        public State State { get; set; }

        protected Int32 currentTime;

        public ElementBase()
        {
            instances.Add(this);
        }

        public virtual Boolean IsFree()
        {
            return State == State.Free;
        }

        public virtual void SetBusy()
        {
            State  = State.Busy;
        }

        public virtual void SetFree()
        {
            State = State.Free;
        }

        public virtual Boolean IsDone()
        {
            Boolean result = false; ;
            return result;
        }

        public static void UpdateTime()
        {
            foreach (var element in instances)
            {
                element.currentTime--;
            }
        }
    }


    public enum State { Free, Busy }
}
