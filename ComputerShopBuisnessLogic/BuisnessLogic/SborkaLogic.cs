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
    public class SborkaLogic : ISborkaLogic 
    {
        private readonly ISborkaStorage _sborkaStorage;
        public SborkaLogic(ISborkaStorage sborkaStorage)
        {
            _sborkaStorage = sborkaStorage;
        }

        public List<SborkaViewModel> Read(SborkaBindingModel model)
        {
            if (model == null)
            {
                return _sborkaStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<SborkaViewModel> { _sborkaStorage.GetElement(model) };
            }
            return _sborkaStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SborkaBindingModel model)
        {
            /*var element = _zakupkaStorage.GetElement(new ZakupkaBindingModel { Id = model.Id });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }*/
            if (model.Id.HasValue)
            {
                _sborkaStorage.Update(model);
            }
            else
            {
                _sborkaStorage.Insert(model);
            }
        }

        public void Delete(SborkaBindingModel model)
        {
            var element = _sborkaStorage.GetElement(new SborkaBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _sborkaStorage.Delete(model);
        }
    }
}
