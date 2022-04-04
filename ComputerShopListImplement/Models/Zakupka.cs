using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopListImplement.Models
{
    public class Zakupka
    {
        public int Id { get; set; }
        public DateTime DateBuy { get; set; }
        public string ZakupkaName { get; set; }
        public string ComplectName { get; set; }
        public int ComplectId { get; set; }
    }
}
