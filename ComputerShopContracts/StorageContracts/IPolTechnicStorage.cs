using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IPolTechnicStorage
    {
        List<PolTechnicViewModel> GetFullList();
        List<PolTechnicViewModel> GetFilteredList(PolTechnicBindingModel model);
        PolTechnicViewModel GetElement(PolTechnicBindingModel model);
        void Insert(PolTechnicBindingModel model);
        void Update(PolTechnicBindingModel model);
        void Delete(PolTechnicBindingModel model);
    }
}
