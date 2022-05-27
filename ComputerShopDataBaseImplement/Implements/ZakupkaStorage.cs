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
    public class ZakupkaStorage : IZakupkaStorage
    {
        public List<ZakupkaViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Zakupkas.Include(rec => rec.postavka).Include(rec => rec.postavshik).Include(rec => rec.complect).Select(CreateModel).ToList();
        }

        public List<ZakupkaViewModel> GetFilteredList(ZakupkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Zakupkas.Include(rec => rec.postavka).Include(rec => rec.postavshik).Include(rec => rec.complect).Where( rec => model.PostavshikId == rec.PostavshikId /*rec => rec.ZakupkaName.Contains(model.ZakupkaName)*/).Select(CreateModel).ToList();
        }

        public ZakupkaViewModel GetElement(ZakupkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var Zakupka = context.Zakupkas.Include(rec => rec.postavka).Include(rec => rec.postavshik).Include(rec => rec.complect).FirstOrDefault(rec => rec.ZakupkaName == model.ZakupkaName || rec.Id == model.Id);
            return Zakupka != null ? CreateModel(Zakupka) : null;
        }

        public void Insert(ZakupkaBindingModel model)
        {
            using var Zakupka = new ComputerShopDataBase();
            using var transaction = Zakupka.Database.BeginTransaction();
            try
            {
                Zakupka.Zakupkas.Add(CreateModel(model, new Zakupka()));
                Zakupka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        public void Update(ZakupkaBindingModel model)
        {
            using var Zakupka = new ComputerShopDataBase();
            using var transaction = Zakupka.Database.BeginTransaction();
            try
            {
                var element = Zakupka.Zakupkas.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                Zakupka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(ZakupkaBindingModel model)
        {

            using var Zakupka = new ComputerShopDataBase();
            Zakupka element = Zakupka.Zakupkas.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                Zakupka.Zakupkas.Remove(element);
                Zakupka.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Zakupka CreateModel(ZakupkaBindingModel model, Zakupka Zakupka)
        {
            Zakupka.PostavshikId = model.PostavshikId;
            Zakupka.ComplectId = model.ComplectId;
            Zakupka.ZakupkaName = model.ZakupkaName;
            Zakupka.DateBuy = model.DateBuy;
            return Zakupka;
        }
        private static ZakupkaViewModel CreateModel(Zakupka Zakupka)
        {
            return new ZakupkaViewModel
            {
                Id = Zakupka.Id,
                ComplectId = Zakupka.ComplectId,
                PostavshikId = Zakupka.PostavshikId,
                ZakupkaName = Zakupka.ZakupkaName,
                DateBuy = Zakupka.DateBuy
            };
        }
    }
}
