using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface ISborkaLogic
    {
        List<SborkaViewModel> Read(SborkaBindingModel model);
        void CreateOrUpdate(SborkaBindingModel model);
        void Delete(SborkaBindingModel model);
    }
}
