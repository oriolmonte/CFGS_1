using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace A2Vehicles
{
    public class XMLManagerImpl : IXMLManager
    {
        private const string path = "CarsSoldInMaryland.xml";
        public List<int> GetDistinctYears()
        {
            var doc = XDocument.Load(path);
            List<int> years = new List<int>();
            foreach(var element in doc.Descendants("year"))
            {
                int elementInt = (int)element;
                if (!years.Contains(elementInt)) years.Add(elementInt);
            }
            return years; 
            
        }

        public Statistic GetSalesByMonth(string month)
        {
            throw new NotImplementedException();
        }

        public Statistic GetSalesByYear(int year)
        {
            Statistic totalYear = new Statistic(year, "ALL");
            var doc = XDocument.Load(path);
            throw new NotImplementedException();

        }

        public Statistic GetSalesByYearAndMonth(int year, string month)
        {
            throw new NotImplementedException();
        }

        public List<Statistic> GetSalesMonthByMonth(int year)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatistics(Statistic oneStatistic)
        {
            throw new NotImplementedException();
        }
    }
}
