using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDataBaseImplement.Models
{
    public class SborkaComplect
    {
        public int Id { get; set; }
        public int ComplectId { get; set; }
        public int SborkaId { get; set; }
        public virtual Complect complect { get; set; }
        public virtual Sborka sborka { get; set; }
    }
}
