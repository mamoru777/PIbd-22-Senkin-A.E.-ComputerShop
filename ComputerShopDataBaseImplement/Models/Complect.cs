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

        [ForeignKey("ComplectId")]
        public virtual List<SborkaComplect> SborkaComplect { get; set; }
        
        public virtual Postavshik postavshik { get; set; }
    }
}
