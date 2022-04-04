using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class PostavshikViewModel
    {
        public int Id { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Почта")]
        public string Mail { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }

    }
}
