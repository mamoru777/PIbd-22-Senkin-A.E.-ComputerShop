using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Zakupka
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateBuy { get; set; }
        [Required]
        public string ZakupkaName { get; set; }
        public int PostavshikId { get; set; }
        public int ComplectId { get; set; }
        public virtual Complect complect { get; set; }
        public virtual Postavshik postavshik { get; set; }

        [ForeignKey("ZakupkaId")]
        public virtual Postavka postavka { get; set; }

    }
}
