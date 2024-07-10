using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progreso3mj.Models
{
    public class SearchHistoryMJ
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SearchTerm { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
