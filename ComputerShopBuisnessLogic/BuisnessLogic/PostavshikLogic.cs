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
    public class PostavshikLogic : IPostavshikLogic
    {
        private readonly IPostavshikStorage _postavshikStorage;
        public PostavshikLogic(IPostavshikStorage postavshikStorage)
        {
            _postavshikStorage = postavshikStorage;
        }

        public List<PostavshikViewModel> Read(PostavshikBindingModel model)
        {
            if (model == null)
            {
                return _postavshikStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<PostavshikViewModel> { _postavshikStorage.GetElement(model) };
            }
            return _postavshikStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PostavshikBindingModel model)
        {
            var element = _postavshikStorage.GetElement(new PostavshikBindingModel { Login = model.Login });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Поставщик с таким логином");
            }
            if (model.Id.HasValue)
            {
                _postavshikStorage.Update(model);
            }
            else
            {
                _postavshikStorage.Insert(model);
            }
        }

        public void Delete(PostavshikBindingModel model)
        {
            var element = _postavshikStorage.GetElement(new PostavshikBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Поставщик не найден");
            }
            _postavshikStorage.Delete(model);
        }
    }
}
