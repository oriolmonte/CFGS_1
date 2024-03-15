using GestioBancaria;
namespace App_Bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Donacio(30);
            Console.WriteLine("Hello, World!");
        }
    }
}