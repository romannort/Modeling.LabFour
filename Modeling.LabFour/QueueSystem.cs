using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour
{
    public class QueueSystem
    {

        private const Int32 ChannelFee = 2; // 2 per hour
        private const Int32 ProcessedRequestPrice = 4; // 4 for one processed request


        public Int32 PipeProcessingTime { get; set; }

        public Double Lambda { get; set; }

        public Int32 Cycles { get; set; }

        public Int32 MinChannelNumber { get; set; }

        public Int32 MaxChannelNumber { get; set; }


        public StatisticsResults Emulate()
        {
            StatisticsResults result = new StatisticsResults();
            // hardcode first =)
            Lambda = 0.1; // 1 request per ten minutes or 6 per hour ( 60 min )
            PipeProcessingTime = 48; // 48 minutes or 0.8 hour * 60 minutes;
            MinChannelNumber = 1;
            MaxChannelNumber = 12;
            Cycles = 60000; // 10 000
            EmitterElement emitter = new EmitterElement(Lambda);
            ICollection<PipeElement> pipes = new List<PipeElement>();

            
            for(Int32 pipesCount = 1; pipesCount < MaxChannelNumber; ++pipesCount)
            {

                pipes.Add(new PipeElement(PipeProcessingTime));
                ProfitData data = new ProfitData() { NumberOfChannels = pipesCount, Costs = 0, Profit = 0};
                emitter.Start();
                
                for (Int32 minute = 0; minute < Cycles; ++minute)
                {
                    // free pipes
                    foreach (var pipe in pipes)
                    {
                        if (pipe.IsDone())
                        {
                            pipe.SetFree();
                            data.Profit += ProcessedRequestPrice;
                        }
                    }
                    // process emitter
                    if (emitter.IsDone())
                    {
                        PipeElement freePipe = pipes.FirstOrDefault(p => p.IsFree());
                        if (freePipe != null)
                        {
                            freePipe.TakeRequest();
                        }
                    }
                    UpdateChannelsCosts(pipes.Count, minute, data);
                    ElementBase.UpdateTime();
                }
                result.Add(data);
            }
            return result;
        }


        private void UpdateChannelsCosts(Int32 numberOfChannels, Int32 takt, ProfitData data)
        {
            if (takt % 60 == 0) // one hour 
            {
                data.Costs += ChannelFee * numberOfChannels;
            }
        }
    }
}