using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopContracts.StorageContracts;

namespace ComputerShopBuisnessLogic.BuisnessLogic
{
    public class PolTechnicLogic : IPolTechnicLogic
    {
        private readonly IPolTechnicStorage _polTechnicStorage;
        public PolTechnicLogic(IPolTechnicStorage polTechnicStorage)
        {
            _polTechnicStorage = polTechnicStorage;
        }

        public List<PolTechnicViewModel> Read(PolTechnicBindingModel model)
        {
            if (model == null)
            {
                return _polTechnicStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<PolTechnicViewModel> { _polTechnicStorage.GetElement(model) };
            }
            return _polTechnicStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PolTechnicBindingModel model)
        {
            var element = _polTechnicStorage.GetElement(new PolTechnicBindingModel { PolTechnicName = model.PolTechnicName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }
            if (model.Id.HasValue)
            {
                _polTechnicStorage.Update(model);
            }
            else
            {
                _polTechnicStorage.Insert(model);
            }
        }

        public void Delete(PolTechnicBindingModel model)
        {
            var element = _polTechnicStorage.GetElement(new PolTechnicBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _polTechnicStorage.Delete(model);
        }
    }
}
