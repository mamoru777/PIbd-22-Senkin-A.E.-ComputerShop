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
    public class ZaiavkaLogic : IZaiavkaLogic
    {
        private readonly IZaiavkaStorage _zaiavkaStorage;
        public ZaiavkaLogic(IZaiavkaStorage zaiavkaStorage)
        {
            _zaiavkaStorage = zaiavkaStorage;
        }

        public List<ZaiavkaViewModel> Read(ZaiavkaBindingModel model)
        {
            if (model == null)
            {
                return _zaiavkaStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<ZaiavkaViewModel> { _zaiavkaStorage.GetElement(model) };
            }
            return _zaiavkaStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ZaiavkaBindingModel model)
        {
            var element = _zaiavkaStorage.GetElement(new ZaiavkaBindingModel { ZaiavkaName = model.ZaiavkaName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }
            if (model.Id.HasValue)
            {
                _zaiavkaStorage.Update(model);
            }
            else
            {
                _zaiavkaStorage.Insert(model);
            }
        }

        public void Delete(ZaiavkaBindingModel model)
        {
            var element = _zaiavkaStorage.GetElement(new ZaiavkaBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _zaiavkaStorage.Delete(model);
        }
    }
}
