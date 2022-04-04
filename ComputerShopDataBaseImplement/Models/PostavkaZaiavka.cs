using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class PostavkaZaiavka
    {
        public int? Id { get; set; }
        public int PostavkaId { get; set; }
        public int ZaiavkaId { get; set; }
        public virtual Postavka postavka { get; set; }
        public virtual Zaiavka zaiavka { get; set; }
    }
}
