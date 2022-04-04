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
    public class ZakupkaLogic : IZakupkaLogic
    {
        private readonly IZakupkaStorage _zakupkaStorage;
        public ZakupkaLogic(IZakupkaStorage zakupkaStorage)
        {
            _zakupkaStorage = zakupkaStorage;
        }

        public List<ZakupkaViewModel> Read(ZakupkaBindingModel model)
        {
            if (model == null)
            {
                return _zakupkaStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<ZakupkaViewModel> { _zakupkaStorage.GetElement(model) };
            }
            return _zakupkaStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ZakupkaBindingModel model)
        {
            var element = _zakupkaStorage.GetElement(new ZakupkaBindingModel { Id = model.Id });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }
            if (model.Id.HasValue)
            {
                _zakupkaStorage.Update(model);
            }
            else
            {
                _zakupkaStorage.Insert(model);
            }
        }

        public void Delete(ZakupkaBindingModel model)
        {
            var element = _zakupkaStorage.GetElement(new ZakupkaBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _zakupkaStorage.Delete(model);
        }
    }
}
