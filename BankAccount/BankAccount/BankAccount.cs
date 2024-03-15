using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBancaria
{
    public class BankAccount
    {
        private static int BANK_ID = 2100;
        private static string BANK_NAME = "TIMOBANK";
        private static double MAX_INT_RATE = 0.02;
        private string accountNumber;
        private string holderName;
        private string holderSurname;
        private double balance;
        private bool locked = false;
        private DateTime openingDate;
        private DateTime ?closingDate=null;
        private DateTime ?lastNegativeBalanceDate = null;
        public BankAccount(string numCC, string holderN, string holderS)
        :this(numCC, holderN,holderS,0)
        {
        }
        public BankAccount(string numCC, string holderN, string holderS, double balance)
        {
            this.accountNumber = numCC;
            this.holderName = holderN;
            this.holderSurname = holderS;
            this.balance = balance;
            this.locked = false;
            this.openingDate = DateTime.Now;
        }
        public void Donacio(double amount)
        {
            balance += amount;
        }
    }
}