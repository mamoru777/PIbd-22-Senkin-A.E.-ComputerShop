using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BuisnessLogicContracts
{
    public interface IPostavkaLogic
    {
        List<PostavkaViewModel> Read(PostavkaBindingModel model);
        void CreateOrUpdate(PostavkaBindingModel model);
        void Delete(PostavkaBindingModel model);
    }
}
