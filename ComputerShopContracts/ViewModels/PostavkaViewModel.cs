using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class PostavkaViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название поставки")]
        public string PostavkaName { get; set; }
        [DisplayName("Дата создания поставки")]
        public DateTime PostavkaCreate { get; set; }
    }
}
