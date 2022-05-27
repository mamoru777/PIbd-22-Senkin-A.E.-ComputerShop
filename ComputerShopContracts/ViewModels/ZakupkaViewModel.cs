using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class ZakupkaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Дата закупки")]
        public DateTime DateBuy { get; set; }
        [DisplayName("Название закупки")]
        public string ZakupkaName { get; set; }
        public string SborkaName { get; set; }
        public int ComplectId { get; set; }
        public int PostavshikId { get; set; }
    }
}
