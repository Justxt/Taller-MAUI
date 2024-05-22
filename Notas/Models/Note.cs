using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.Models
{
    internal class Note
    {
        public string Filename { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public string DisplayDate
        {
            get
            {   
                var today = DateTime.Today;
                var yesterday = today.AddDays(-1);
                var CurrentDate = today.DayOfWeek;

                if (Date.Date == today.Date)
                    return "Hoy";
                else if (Date.Date == yesterday.Date)
                    return "Ayer";
                else if (Date.Date > yesterday.Date && Date.Date < today.Date)
                    return CurrentDate.ToString();
                else
                    return Date.ToString("dd/MM/yyyy");
            }
        }
    }
}
