using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using ComputerShopDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerShopDataBaseImplement.Implements
{
    public class SborkaStorage : ISborkaStorage
    {
        public List<SborkaViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Sborkas.Include(rec => rec.Complects).Include(rec => rec.SborkaZaiavkas).ThenInclude(rec => rec.zaiavka).Include(rec => rec.postavshik).Select(CreateModel).ToList();
        }

        public List<SborkaViewModel> GetFilteredList(SborkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Sborkas.Include(rec => rec.Complects).Include(rec => rec.SborkaZaiavkas).ThenInclude(rec => rec.zaiavka).Include(rec => rec.postavshik).Where(rec => model.PostavshikId == rec.PostavshikId/*rec.SborkaName.Contains(model.SborkaName)*/).Select(CreateModel).ToList();
        }

        public SborkaViewModel GetElement(SborkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var Sborka = context.Sborkas.Include(rec => rec.Complects).Include(rec => rec.SborkaZaiavkas).ThenInclude(rec => rec.zaiavka).Include(rec => rec.postavshik).FirstOrDefault(rec => rec.SborkaName == model.SborkaName || rec.Id == model.Id);
            return Sborka != null ? CreateModel(Sborka) : null;
        }

        public void Insert(SborkaBindingModel model)
        {
            using var Sborka = new ComputerShopDataBase();
            using var transaction = Sborka.Database.BeginTransaction();
            try
            {
                Sborka.Sborkas.Add(CreateModel(model, new Sborka()));
                Sborka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        public void Update(SborkaBindingModel model)
        {
            using var Sborka = new ComputerShopDataBase();
            using var transaction = Sborka.Database.BeginTransaction();
            try
            {
                var element = Sborka.Sborkas.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                Sborka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(SborkaBindingModel model)
        {

            using var Sborka = new ComputerShopDataBase();
            Sborka element = Sborka.Sborkas.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                Sborka.Sborkas.Remove(element);
                Sborka.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Sborka CreateModel(SborkaBindingModel model, Sborka Sborka)
        {

            Sborka.PostavshikId = model.PostavshikId;
            Sborka.SborkaName = model.SborkaName;
            Sborka.Sum = model.Sum;
            return Sborka;
        }
        private static SborkaViewModel CreateModel(Sborka Sborka)
        {
            return new SborkaViewModel
            {
                Id = Sborka.Id,
                PostavshikId = Sborka.PostavshikId,
                SborkaName = Sborka.SborkaName,
                Sum = Sborka.Sum
            };
        }
    }
}
