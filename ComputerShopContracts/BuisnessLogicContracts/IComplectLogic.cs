using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IComplectLogic
    {
        List<ComplectViewModel> Read(ComplectBindingModel model);
        void CreateOrUpdate(ComplectBindingModel model);
        void Delete(ComplectBindingModel model);
    }
}
