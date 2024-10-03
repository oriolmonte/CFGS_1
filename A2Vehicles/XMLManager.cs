using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Vehicles
{
    internal interface XMLManager
    {
        public List<int> GetDistinctYears();
        public Statistic GetSalesByYear(int year);
        List<Statistic> GetSalesMonthByMonth(int year);
        public Statistic GetSalesByMonth(string month);
        public Statistic GetSalesByYearAndMonth(int year, string month);
        public bool UpdateStatistics(Statistic oneStatistic);
    }
}
