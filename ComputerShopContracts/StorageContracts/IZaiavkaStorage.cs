using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IZaiavkaStorage
    {
        List<ZaiavkaViewModel> GetFullList();
        List<ZaiavkaViewModel> GetFilteredList(ZaiavkaBindingModel model);
        ZaiavkaViewModel GetElement(ZaiavkaBindingModel model);
        void Insert(ZaiavkaBindingModel model);
        void Update(ZaiavkaBindingModel model);
        void Delete(ZaiavkaBindingModel model);
    }
}
