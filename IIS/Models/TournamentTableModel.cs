using IIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TournamentTableModel
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int Prize { get; set; }
        public int Entry { get; set; }
        public TournamentType Type { get; set; }
    }
}
