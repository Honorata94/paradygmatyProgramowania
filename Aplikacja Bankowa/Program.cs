using System;

namespace Aplikacja_Bankowa
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new KontoBankowe("Honorata", 10000);
            Console.WriteLine($"Konto {account.Numer} zostało utworzone przez osobę o imieniu {account.Wlasciciel} z początkowym saldem {account.Saldo} .");

            account.DokonanieWyplaty(800, DateTime.Now, "Podstawowe rachunki");
            Console.WriteLine(account.Saldo);
            account.StworzenieDepozytu(100, DateTime.Now, "dodatkowa wpłata");
            Console.WriteLine(account.Saldo);

            Console.WriteLine(account.GetAccountHistory());

           
            
        }
    }
}
   
