using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using ComputerShopContracts.StorageContracts;
using ComputerShopListImplement.Models;

namespace ComputerShopListImplement.Implements
{
    public class ComplectStorage : IComplectStorage
    {
        private readonly DataListSingleton source;
        public ComplectStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ComplectViewModel> GetFullList()
        {
            var result = new List<ComplectViewModel>();
            foreach (var complect in source.Complects)
            {
                result.Add(CreateModel(complect));
            }
            return result;
        }

        public List<ComplectViewModel> GetFilteredList(ComplectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<ComplectViewModel>();
            foreach (var complect in source.Complects)
            {
                result.Add(CreateModel(complect));
            }
            return result;
        }

        public ComplectViewModel GetElement(ComplectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var complect in source.Complects)
            {
                if (complect.Id == model.Id || complect.ComplectName == model.ComplectName)
                {
                    return CreateModel(complect);
                }
            }
            return null;
        }

        public void Insert(ComplectBindingModel model)
        {
            var tempComplect = new Complect { Id = 1 };
            foreach (var complect in source.Complects)
            {
                if (complect.Id >= tempComplect.Id)
                {
                    tempComplect.Id = complect.Id + 1;
                }
            }
            source.Complects.Add(CreateModel(model, tempComplect));
        }

        public void Update(ComplectBindingModel model)
        {
            Complect tempComplect = null;
            foreach (var complect in source.Complects)
            {
                if (complect.Id == model.Id)
                {
                    tempComplect = complect;
                }
            }

            if (tempComplect == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempComplect);
        }

        public void Delete(ComplectBindingModel model)
        {
            for (int i = 0; i < source.Complects.Count; i++)
            {
                if (source.Complects[i].Id == model.Id.Value)
                {
                    source.Complects.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private static Complect CreateModel(ComplectBindingModel model, Complect complect)
        {
            complect.ComplectName = model.ComplectName;
            complect.Price = model.Price;
            return complect;
        }

        private static ComplectViewModel CreateModel(Complect complect)
        {
            return new ComplectViewModel
            {
                Id = complect.Id,
                ComplectName = complect.ComplectName,
                Price = complect.Price
            };
        }
            
    }
}
