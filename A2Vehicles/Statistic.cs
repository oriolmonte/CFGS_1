using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Vehicles
{
    public class Statistic
    {
        private int _year;
        private string _month;
        private int _totalNews=0;
        private int _totalUsed=0;
        private int _used=0;
        private int _new=0;

        public Statistic(int year, string month, int totalNews, int totalUsed, int used, int pnew)
        {
            _year = year;
            _month = month;
            _totalNews = totalNews;
            _totalUsed = totalUsed;
            _used = used;
            _new = pnew;
        }
        public Statistic(int year, string month) 
        {
            _year=year;
            _month = month;
        }
        

        public int Year { get => _year; set => _year = value; }
        public string Month { get => _month; set => _month = value; }
        public int TotalNews { get => _totalNews; set => _totalNews = value; }
        public int TotalUsed { get => _totalUsed; set => _totalUsed = value; }
        public int Used { get => _used; set => _used = value; }
        public int New { get => _new; set => _new = value; }
    }
}
