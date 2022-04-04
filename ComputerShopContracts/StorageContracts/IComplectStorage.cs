using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.StorageContracts
{
    public interface IComplectStorage
    {
        List<ComplectViewModel> GetFullList();
        List<ComplectViewModel> GetFilteredList(ComplectBindingModel model);
        ComplectViewModel GetElement(ComplectBindingModel model);
        void Insert(ComplectBindingModel model);
        void Update(ComplectBindingModel model);
        void Delete(ComplectBindingModel model);
    }
}
