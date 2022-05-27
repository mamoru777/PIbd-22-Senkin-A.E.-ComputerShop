using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class PolTechnic
    {
        public int? Id { get; set; }
        [Required]
        public DateTime DatePos { get; set; }
        public int PostavkaId {get; set;}
        public string PolTechnicName { get; set; }
        [ForeignKey("PolTechnicId")]
        public virtual List<ComplectPolTechnic> ComplectPolTechnic { get; set; }
    }
}
