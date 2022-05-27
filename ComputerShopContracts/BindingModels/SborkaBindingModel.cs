using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class SborkaBindingModel
    {
        public int? Id { get; set; }
        public string SborkaName { get; set; }
        public decimal Sum { get; set; }
        public int PostavshikId { get; set; }
        public Dictionary<int, string> SborkaComplect { get; set; }
    }
}
