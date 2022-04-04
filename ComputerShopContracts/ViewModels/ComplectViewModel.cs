using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class ComplectViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название комплектующего")]
        public string ComplectName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
