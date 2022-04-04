using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IPostavshikStorage
    {
        List<PostavshikViewModel> GetFullList();
        List<PostavshikViewModel> GetFilteredList(PostavshikBindingModel model);
        PostavshikViewModel GetElement(PostavshikBindingModel model);
        void Insert(PostavshikBindingModel model);
        void Update(PostavshikBindingModel model);
        void Delete(PostavshikBindingModel model);
    }
}
