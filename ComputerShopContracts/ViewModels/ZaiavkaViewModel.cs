using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class ZaiavkaViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название Заявки")]
        public string ZaiavkaName { get; set; }

        public Dictionary<int, string> SborkaZaiavka { get; set; }
    }
}
