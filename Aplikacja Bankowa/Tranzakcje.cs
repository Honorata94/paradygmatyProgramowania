using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Bankowa
{
    class Tranzakcje
    {
        public decimal Account { get; }
        public DateTime Date { get; }
        public string Note { get; }

        public Tranzakcje(decimal Account, DateTime Date, string Note)
        {
            this.Account = Account;
            this.Date = Date;
            this.Note = Note;
        }
        
    }
}
