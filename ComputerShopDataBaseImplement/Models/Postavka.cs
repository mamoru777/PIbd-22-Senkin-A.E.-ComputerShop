using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Postavka
    {
        public int? Id { get; set; }
        public string PostavkaName { get; set; }
        public DateTime PostavkaCreate { get; set; }
        [ForeignKey("PostavkaId")]
        public virtual List<PostavkaZaiavka> PostavkaZaiavkas { get; set; }
        [ForeignKey("PostavlaId")]
        public virtual List<PolTechnic> poltechnic { get; set; }

    }
}
