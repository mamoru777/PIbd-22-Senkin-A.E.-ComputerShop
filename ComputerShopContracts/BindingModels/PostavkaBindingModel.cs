using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class PostavkaBindingModel
    {
        public int? Id { get; set; }
        public string PostavkaName { get; set; }
        public DateTime PostavkaCreate { get; set; }
    }
}
