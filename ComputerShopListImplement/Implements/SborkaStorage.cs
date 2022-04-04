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
    public class SborkaStorage : ISborkaStorage
    {
        private readonly DataListSingleton source;
        public SborkaStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SborkaViewModel> GetFullList()
        {
            var result = new List<SborkaViewModel>();
            foreach (var sborka in source.Sborkas)
            {
                result.Add(CreateModel(sborka));
            }
            return result;
        }

        public List<SborkaViewModel> GetFilteredList(SborkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<SborkaViewModel>();
            foreach (var sborka in source.Sborkas)
            {
                if (sborka.SborkaName.Contains(model.SborkaName))
                {
                    result.Add(CreateModel(sborka));
                }
            }
            return result;
        }

        public SborkaViewModel GetElement(SborkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var sborka in source.Sborkas)
            {
                if (sborka.Id == model.Id || sborka.SborkaName == model.SborkaName)
                {
                    return CreateModel(sborka);
                }
            }
            return null;
        }

        public void Insert(SborkaBindingModel model)
        {
            var tempSborka = new Sborka { Id = 1, SborkaComplect = new Dictionary<int, int>() };
            foreach (var sborka in source.Sborkas)
            {
                if (sborka.Id >= tempSborka.Id)
                {
                    tempSborka.Id = sborka.Id + 1;
                }
            }

            source.Sborkas.Add(CreateModel(model, tempSborka));
        }

        public void Update(SborkaBindingModel model)
        {
            Sborka tempSborka = null;
            foreach (var sborka in source.Sborkas)
            {
                if (sborka.Id == model.Id)
                {
                    tempSborka = sborka;
                }
            }

            if (tempSborka == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempSborka);
        }

        public void Delete(SborkaBindingModel model)
        {
            for (int i = 0; i < source.Sborkas.Count; ++i)
            {
                if (source.Sborkas[i].Id == model.Id)
                {
                    source.Sborkas.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private static Sborka CreateModel(SborkaBindingModel model, Sborka sborka)
        {
            sborka.SborkaName = model.SborkaName;
            sborka.Sum = model.Sum;
            foreach(var key in sborka.SborkaComplect.Keys.ToList())
            {
                if(!model.SborkaComplect.ContainsKey(key))
                {
                    sborka.SborkaComplect.Remove(key);
                }
            }

            foreach (var complect in model.SborkaComplect)
            {
                if (sborka.SborkaComplect.ContainsKey(complect.Key))
                {
                    sborka.SborkaComplect[complect.Key] = model.SborkaComplect[complect.Key].Item2;
                }
                else
                {
                    sborka.SborkaComplect.Add(complect.Key, model.SborkaComplect[complect.Key].Item2);
                }
            }
            return sborka;
        }

        private SborkaViewModel CreateModel(Sborka sborka)
        {
            var sborkaComplect = new Dictionary<int, (string, int)>();
            foreach (var pc in sborka.SborkaComplect)
            {
                string complectName = string.Empty;
                foreach (var complect in source.Complects)
                {
                    if (pc.Key == complect.Id)
                    {
                        complectName = complect.ComplectName;
                        break;
                    }
                }
                sborkaComplect.Add(pc.Key, (complectName, pc.Value));
            }
            return new SborkaViewModel
            {
                Id = sborka.Id,
                SborkaName = sborka.SborkaName,
                Sum = sborka.Sum,
                SborkaComplect = sborkaComplect
            };
        }
    }
}
