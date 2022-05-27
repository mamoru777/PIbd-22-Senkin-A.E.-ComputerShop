using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Sborka
    {
        public int Id { get; set; }
        [Required]
        public string SborkaName { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [ForeignKey("SborkaId")]
        public virtual List<SborkaComplect> SborkaComplect { get; set; }

        [ForeignKey("SborkaId")]
        public virtual List<SborkaZaiavka> SborkaZaiavkas { get; set; }
        public virtual Postavshik postavshik { get; set; }
        public virtual int PostavshikId { get; set; }
    }
}
