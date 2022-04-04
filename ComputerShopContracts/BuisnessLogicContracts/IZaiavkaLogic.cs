using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IZaiavkaLogic
    {
        List<ZaiavkaViewModel> Read(ZaiavkaBindingModel model);
        void CreateOrUpdate(ZaiavkaBindingModel model);
        void Delete(ZaiavkaBindingModel model);
    }
}
