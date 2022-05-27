using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Postavshik
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("PostavshikId")]
        public virtual List<Complect> Complects { get; set; }
        [ForeignKey("PostavshikId")]
        public virtual List<Sborka> Sborkas { get; set; }
        [ForeignKey("PostavshikId")]
        public virtual List<Zakupka> Zakupkas { get; set; }
    }
}
