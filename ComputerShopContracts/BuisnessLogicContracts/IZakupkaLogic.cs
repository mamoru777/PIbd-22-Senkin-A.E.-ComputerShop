using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IZakupkaLogic
    {
        List<ZakupkaViewModel> Read(ZakupkaBindingModel model);
        void CreateOrUpdate(ZakupkaBindingModel model);
        void Delete(ZakupkaBindingModel model);
    }
}
