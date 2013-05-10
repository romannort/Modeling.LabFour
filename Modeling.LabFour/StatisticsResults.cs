using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour
{
    public class StatisticsResults
    {
        public ICollection<ProfitData> results = new List<ProfitData>();

        public Boolean Add(Int32 numberOfChannels, Int32 costs, Int32 profit)
        {
            ProfitData newData = new ProfitData()
            {
                NumberOfChannels = numberOfChannels,
                Costs = costs,
                Profit = profit
            };
            ProfitData lastProfit = results.Last();
            results.Add(newData);
            return MaxProfitFound(lastProfit, newData);
        }

        public Boolean Add(ProfitData newData)
        {
            if (results.Any())
            {
                ProfitData lastProfit = results.Last();
                results.Add(newData);
                return MaxProfitFound(lastProfit, newData);
            }
            else
            {
                results.Add(newData);
                return false;
            }
        }


        private Boolean MaxProfitFound(ProfitData lastProfit, ProfitData newProfit)
        {
            if (lastProfit.Profit - lastProfit.Costs > newProfit.Profit - newProfit.Costs)
            //if (lastProfit.Profit >= newProfit.Profit &&  lastProfit.Costs <= newProfit.Costs)
            {
                return true;
            }
            return false;
        }
    }
}
