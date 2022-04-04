using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class SborkaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название сборки")]
        public string SborkaName { get; set; }
        [DisplayName("Цена сборки")]
        public decimal Sum { get; set; }
        public Dictionary<int, (string, int)> SborkaComplect { get; set; }
    }
}
