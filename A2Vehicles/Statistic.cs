using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Vehicles
{
    public class Statistic
    {
        private string _year;
        private string _month;
        private double _incomeNew=0;
        private double _incomeUsed=0;
        private int _used=0;
        private int _new=0;

        public Statistic(string year, string month, double incomeNew, double incomeUsed, int used, int pnew)
        {
            _year = year;
            _month = month;
            _incomeNew = incomeNew;
            _incomeUsed = incomeUsed;
            _used = used;
            _new = pnew;
        }
        public Statistic(string year, string month) 
        {
            _year=year;
            _month = month;
        }
        

        public string Year { get => _year; set => _year = value; }
        public string Month { get => _month; set => _month = value; }
        public double IncomeNew { get => _incomeNew; set => _incomeNew = value; }
        public double IncomeUsed { get => _incomeUsed; set => _incomeUsed = value; }
        public int Used { get => _used; set => _used = value; }
        public int New { get => _new; set => _new = value; }
    }
}
