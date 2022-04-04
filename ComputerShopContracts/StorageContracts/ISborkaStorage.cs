using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface ISborkaStorage
    {
        List<SborkaViewModel> GetFullList();
        List<SborkaViewModel> GetFilteredList(SborkaBindingModel model);
        SborkaViewModel GetElement(SborkaBindingModel model);
        void Insert(SborkaBindingModel model);
        void Update(SborkaBindingModel model);
        void Delete(SborkaBindingModel model);
    }
}
