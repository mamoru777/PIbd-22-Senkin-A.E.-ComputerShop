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
    public class ComplectLogic : IComplectLogic
    {
        private readonly IComplectStorage _complectStorage;
        public ComplectLogic(IComplectStorage complectStorage)
        {
            _complectStorage = complectStorage;
        }

        public List<ComplectViewModel> Read(ComplectBindingModel model)
        {
            if(model==null)
            {
                return _complectStorage.GetFullList();
            }

            if(model.Id.HasValue)
            {
                return new List<ComplectViewModel> { _complectStorage.GetElement(model) };
            }
            return _complectStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ComplectBindingModel model)
        {
            var element = _complectStorage.GetElement(new ComplectBindingModel { ComplectName = model.ComplectName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }
            if (model.Id.HasValue)
            {
                _complectStorage.Update(model);
            }
            else
            {
                _complectStorage.Insert(model);
            }
        }

        public void Delete(ComplectBindingModel model)
        {
            var element = _complectStorage.GetElement(new ComplectBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _complectStorage.Delete(model);
        }

    }
}
