using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Complect
    {
        public int Id { get; set; }

        [Required]
        public string ComplectName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int PostavshikId { get; set; }
        public int SborkaId { get; set; }
        public int ZakupkaId { get; set; }
        
        [ForeignKey("ComplectId")]
        public virtual Zakupka zakupka { get; set; }

        public virtual Postavshik postavshik { get; set; }
        public virtual Sborka sborka { get; set; }
    }
}
