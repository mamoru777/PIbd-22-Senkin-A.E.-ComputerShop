using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class ZaiavkaBindingModel
    {
        public int? Id { get; set; }
        public string ZaiavkaName { get; set; }
        //public virtual List<PostavkaZaiavka> PostavkaZaiavkas { get; set; }
    }
}
