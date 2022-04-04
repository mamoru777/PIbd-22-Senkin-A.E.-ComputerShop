using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IPostavkaStorage
    {
        List<PostavkaViewModel> GetFullList();
        List<PostavkaViewModel> GetFilteredList(PostavkaBindingModel model);
        PostavkaViewModel GetElement(PostavkaBindingModel model);
        void Insert(PostavkaBindingModel model);
        void Update(PostavkaBindingModel model);
        void Delete(PostavkaBindingModel model);
    }
}
