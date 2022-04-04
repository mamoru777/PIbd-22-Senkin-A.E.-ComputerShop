using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDataBaseImplement.Models
{
    public class SborkaZaiavka
    {
        public int? Id { get; set; }
        public int SborkaId { get; set; }
        public int ZaiavkaId { get; set; }

        public virtual Sborka sborka { get; set; }
        public virtual Zaiavka zaiavka { get; set; }
    }
}
