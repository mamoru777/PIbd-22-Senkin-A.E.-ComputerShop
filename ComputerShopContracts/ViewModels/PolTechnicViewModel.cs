using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class PolTechnicViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата поставки")]
        public DateTime DatePos { get; set; }
        [DisplayName("Название поставки")]
        public string PolTechnicName { get; set; }
        public int PostavkaId { get; set; }
    }
}
