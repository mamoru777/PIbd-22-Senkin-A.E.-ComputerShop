using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopListImplement.Models
{
    public class Sborka
    {
        public int Id { get; set; }
        public string SborkaName { get; set; }
        public decimal Sum { get; set; }
        public Dictionary<int, int> SborkaComplect { get; set; }
    }
}
