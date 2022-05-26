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
    public class ZakupkaStorage : IZakupkaStorage
    {
        private readonly DataListSingleton source;
        public ZakupkaStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ZakupkaViewModel> GetFullList()
        {
            var result = new List<ZakupkaViewModel>();
            foreach (var zakupka in source.Zakupkas)
            {
                result.Add(CreateModel(zakupka));
            }
            return result;
        }

        public List<ZakupkaViewModel> GetFilteredList(ZakupkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<ZakupkaViewModel>();
            foreach (var zakupka in source.Zakupkas)
            {
                if (zakupka.ZakupkaName.Contains(model.ZakupkaName))
                {
                    result.Add(CreateModel(zakupka));
                }
            }
            return result;
        }

        public ZakupkaViewModel GetElement(ZakupkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var zakupka in source.Zakupkas)
            {
                if (zakupka.Id == model.Id || zakupka.ZakupkaName == model.ZakupkaName)
                {
                    return CreateModel(zakupka);
                }
            }
            return null;
        }

        public void Insert(ZakupkaBindingModel model)
        {
            var tempZakupka = new Zakupka { Id = 1 };
            foreach (var zakupka in source.Zakupkas)
            {
                if (zakupka.Id >= tempZakupka.Id)
                {
                    tempZakupka.Id = zakupka.Id + 1;
                }
            }
            source.Zakupkas.Add(CreateModel(model, tempZakupka));
        }

        public void Update(ZakupkaBindingModel model)
        {
            Zakupka tempZakupka = null;
            foreach (var zakupka in source.Zakupkas)
            {
                if (zakupka.Id == model.Id)
                {
                    tempZakupka = zakupka;
                }
            }
            if (tempZakupka == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempZakupka);
        }

        public void Delete(ZakupkaBindingModel model)
        {
            for (int i = 0; i < source.Zakupkas.Count; ++i)
            {
                if (source.Zakupkas[i].Id == model.Id)
                {
                    source.Zakupkas.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private static Zakupka CreateModel(ZakupkaBindingModel model, Zakupka zakupka)
        {
            zakupka.ComplectId = model.ComplectId;
            zakupka.ZakupkaName = model.ZakupkaName;
            zakupka.DateBuy = model.DateBuy;
            return zakupka;
        }

        private  ZakupkaViewModel CreateModel(Zakupka zakupka)
        {
            string complectName = string.Empty;
            foreach (var complect in source.Complects)
            {
                complectName = complect.ComplectName;
            }
            return new ZakupkaViewModel
            {
                ComplectId = zakupka.ComplectId,
                SborkaName = zakupka.ComplectName,
                Id = zakupka.Id,
                ZakupkaName = zakupka.ZakupkaName,
                DateBuy = zakupka.DateBuy
            };
        }
    }
}
