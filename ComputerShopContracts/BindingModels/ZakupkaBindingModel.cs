using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class ZakupkaBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateBuy { get; set; }
        public string ZakupkaName { get; set; }
        public int ComplectId { get; set; }
        public int PostavshikId { get; set; }
    }
}
