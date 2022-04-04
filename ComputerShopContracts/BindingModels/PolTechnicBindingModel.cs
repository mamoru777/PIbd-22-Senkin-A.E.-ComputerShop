using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class PolTechnicBindingModel
    {
        public int? Id { get; set; }
        public DateTime DatePos { get; set; }
        public int PostavkaId { get; set; }
        public string PolTechnicName { get; set; }
    }
}
