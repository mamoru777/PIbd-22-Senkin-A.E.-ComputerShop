using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IPolTechnicLogic
    {
        List<PolTechnicViewModel> Read(PolTechnicBindingModel model);
        void CreateOrUpdate(PolTechnicBindingModel model);
        void Delete(PolTechnicBindingModel model);
    }
}
