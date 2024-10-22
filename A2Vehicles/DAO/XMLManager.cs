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
        private string[] mesos = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
        public List<int> GetDistinctYears()
        {
            var doc = XDocument.Load(path);
            var years = doc.Descendants("year").Select(y => int.Parse(y.Value)).Distinct().ToList();
            return years;
        }

        public Statistic GetSalesByMonth(string month)
        {
            if (!mesos.Contains(month)) throw new Exception("Month not found");
            var doc = XDocument.Load(path);
            var query = doc.Descendants("row")
                .Descendants("row")
                .Where(y => y.Element("month").Value == month);
            return GroupBy(query,mes:month);
        }

        public Statistic GetSalesByYear(int year)
        {
            var years = GetDistinctYears();
            if (!years.Contains(year)) throw new Exception("Year not found");
            var doc = XDocument.Load(path);
            var query = doc.Descendants("row")
                .Descendants("row")
                .Where(y => (int)y.Element("year") == year);
            return GroupBy(query,any:year.ToString());

        }

        public Statistic GetSalesByYearAndMonth(int year, string month)
        {
            var years = GetDistinctYears();
            if (!years.Contains(year)) throw new Exception("Year not found");
            if (!mesos.Contains(month)) throw new Exception("Month not found");
            var doc = XDocument.Load(path);
            Statistic res;
            var query = doc.Descendants("row")
                .Descendants("row")
                .Where(y => y.Element("month").Value == month).Where(y => (int)y.Element("year") == year);
            res = new Statistic(
                year.ToString(),
                month,
                long.Parse(query.First().Element("total_sales_new").Value),
                long.Parse(query.First().Element("total_sales_used").Value),
                int.Parse(query.First().Element("used").Value),
                int.Parse(query.First().Element("new").Value)
                ) ;
            return res;
        }

        public List<Statistic> GetSalesMonthByMonth(int year)
        {
            var years = GetDistinctYears();
            if (!years.Contains(year)) throw new Exception("Year not found");
            List<Statistic> result = new List<Statistic>();
            var doc = XDocument.Load(path);
            var query = doc.Descendants("row")
                .Descendants("row")
                .Where(y => (int)y.Element("year") == year);
            foreach( var row in query)
            {
                result.Add(new Statistic(year.ToString(), 
                                row.Element("month").Value, 
                                long.Parse(row.Element("total_sales_new").Value), 
                                long.Parse(row.Element("total_sales_used").Value), 
                                int.Parse(row.Element("used").Value),
                                int.Parse(row.Element("new").Value)));
            }
            return result;
        }

        public bool UpdateStatistics(Statistic oneStatistic)
        {
            var doc = XDocument.Load(path);
            var trobat = false;
            var query = doc.Descendants("row")
            .Descendants("row")
            .Where(y => y.Element("month").Value == oneStatistic.Month).Where(y => (int)y.Element("year") == int.Parse(oneStatistic.Year)).FirstOrDefault();
            if (query!=null)
            {
                query.Element("used").Value = oneStatistic.Used.ToString();
                query.Element("new").Value = oneStatistic.New.ToString();
                query.Element("total_sales_used").Value = oneStatistic.IncomeUsed.ToString();
                query.Element("total_sales_new").Value = oneStatistic.IncomeNew.ToString();
                doc.Save(path);
                trobat = true;
            }
            return trobat;
        }

        private Statistic GroupBy(IEnumerable<XElement> query, string any="ALL", string mes="ALL")
        {
            int used = query.Sum(y => int.Parse(y.Element("used").Value));
            int nou = query.Sum(y => int.Parse(y.Element("new").Value));
            long incomeNew = query.Sum(y => long.Parse(y.Element("total_sales_new").Value));
            long incomeUsed = query.Sum(y => long.Parse(y.Element("total_sales_used").Value));
            Statistic totalYear = new Statistic(any, mes, incomeNew, incomeUsed, used, nou);
            return totalYear;
        }

        
    }
}
