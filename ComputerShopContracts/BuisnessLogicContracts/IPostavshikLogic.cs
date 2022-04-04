using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;


namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IPostavshikLogic
    {
        List<PostavshikViewModel> Read(PostavshikBindingModel model);
        void CreateOrUpdate(PostavshikBindingModel model);
        void Delete(PostavshikBindingModel model);
    }
}
