using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IZakupkaStorage
    {
        List<ZakupkaViewModel> GetFullList();
        List<ZakupkaViewModel> GetFilteredList(ZakupkaBindingModel model);
        ZakupkaViewModel GetElement(ZakupkaBindingModel model);
        void Insert(ZakupkaBindingModel model);
        void Update(ZakupkaBindingModel model);
        void Delete(ZakupkaBindingModel model);
    }
}
