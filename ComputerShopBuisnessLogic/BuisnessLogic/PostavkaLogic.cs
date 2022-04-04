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
    public class PostavkaLogic : IPostavkaLogic
    {
        private readonly IPostavkaStorage _postavkaStorage;
        public PostavkaLogic(IPostavkaStorage postavkaStorage)
        {
            _postavkaStorage = postavkaStorage;
        }

        public List<PostavkaViewModel> Read(PostavkaBindingModel model)
        {
            if (model == null)
            {
                return _postavkaStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<PostavkaViewModel> { _postavkaStorage.GetElement(model) };
            }
            return _postavkaStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PostavkaBindingModel model)
        {
            var element = _postavkaStorage.GetElement(new PostavkaBindingModel { PostavkaName = model.PostavkaName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть комплектующее с таким названием");
            }
            if (model.Id.HasValue)
            {
                _postavkaStorage.Update(model);
            }
            else
            {
                _postavkaStorage.Insert(model);
            }
        }

        public void Delete(PostavkaBindingModel model)
        {
            var element = _postavkaStorage.GetElement(new PostavkaBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _postavkaStorage.Delete(model);
        }
    }
}
