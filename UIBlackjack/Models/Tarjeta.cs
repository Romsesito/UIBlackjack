using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace UIBlackjack.Models
{
    public class Tarjeta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NumTarjeta { get; set; }
        public string FechaEXP { get; set; }
        public string CVV { get; set; }
    }
}
