using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Bankowa
{
    class KontoBankowe
    {

        public string Numer { get; }
        public string Wlasciciel { get; set; }
        public decimal Saldo
        {
            get
            {
                decimal Saldo = 0;
                foreach (var item in WszystkieTranzakcje)
                {
                    Saldo += item.Account;
                }

                return Saldo;
            }
            
        }
        private static int NumerKonta = 100213;
        public KontoBankowe(string nazwisko, decimal Saldopoczątkowe)
        {
            this.Numer = NumerKonta.ToString();
            NumerKonta++;

            this.Wlasciciel = nazwisko;
            StworzenieDepozytu(Saldopoczątkowe, DateTime.Now, "Saldo początkowe");

        }
        public void StworzenieDepozytu(decimal account, DateTime date, string note)
        {
            if (account <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(account), "Kwota wpłaty musi być dodatnia");
            }
            var depozyt = new Tranzakcje(account, date, note);
            WszystkieTranzakcje.Add(depozyt);
        }

        private List<Tranzakcje> WszystkieTranzakcje = new List<Tranzakcje>();

        public void DokonanieWyplaty(decimal account, DateTime date, string note)
        {
            if (account <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(account), "Kwota wypłaty musi być dodatnia");
            }
            if (Saldo - account < 0)
            {
                throw new InvalidOperationException("Brak wystarczających środków na tę wypłatę");
            }
            var wycofanie = new Tranzakcje(-account, date, note);
            WszystkieTranzakcje.Add(wycofanie);
        }
       
            public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal saldo = 0;
            
            foreach (var item in WszystkieTranzakcje)
            {
                saldo += item.Account;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Account}\t{saldo}\t{item.Note}");
            }

            return report.ToString();
        }
    
}
    }

