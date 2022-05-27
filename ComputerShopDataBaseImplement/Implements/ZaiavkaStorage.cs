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
    public class ZaiavkaStorage : IZaiavkaStorage
    {
        public List<ZaiavkaViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Zaiavkas.Include(rec => rec.SborkaZaiavka).ThenInclude(rec => rec.sborka).Select(CreateModel).ToList();
        }

        public List<ZaiavkaViewModel> GetFilteredList(ZaiavkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Zaiavkas.Include(rec => rec.SborkaZaiavka).ThenInclude(rec => rec.sborka).Where(rec => rec.ZaiavkaName.Contains(model.ZaiavkaName)).Select(CreateModel).ToList();
        }

        public ZaiavkaViewModel GetElement(ZaiavkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var Zaiavka = context.Zaiavkas.Include(rec => rec.SborkaZaiavka).ThenInclude(rec => rec.sborka).FirstOrDefault(rec => rec.ZaiavkaName == model.ZaiavkaName || rec.Id == model.Id);
            return Zaiavka != null ? CreateModel(Zaiavka) : null;
        }

        public void Insert(ZaiavkaBindingModel model)
        {
            using var Zaiavka = new ComputerShopDataBase();
            using var transaction = Zaiavka.Database.BeginTransaction();
            try
            {
                Zaiavka.Zaiavkas.Add(CreateModel(model, new Zaiavka(), Zaiavka));
                Zaiavka.SaveChanges();
                transaction.Commit();

            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        public void Update(ZaiavkaBindingModel model)
        {
            using var Zaiavka = new ComputerShopDataBase();
            using var transaction = Zaiavka.Database.BeginTransaction();
            try
            {
                var element = Zaiavka.Zaiavkas.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, Zaiavka);
                Zaiavka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(ZaiavkaBindingModel model)
        {

            using var Zaiavka = new ComputerShopDataBase();
            Zaiavka element = Zaiavka.Zaiavkas.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                Zaiavka.Zaiavkas.Remove(element);
                Zaiavka.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Zaiavka CreateModel(ZaiavkaBindingModel model, Zaiavka Zaiavka, ComputerShopDataBase context)
        {

            Zaiavka.ZaiavkaName = model.ZaiavkaName;
            if (model.Id.HasValue)
            {
                var sborkaZaiavka = context.SborkaZaiavkas.Where(rec => rec.ZaiavkaId == model.Id.Value).ToList();
                context.SborkaZaiavkas.RemoveRange(sborkaZaiavka);
                /*var learningPlanStudents = context.LearningPlanStudents.Where(rec => rec.LearningPlanId == model.Id.Value).ToList();
                context.LearningPlanStudents.RemoveRange(learningPlanStudents);
                context.SaveChanges();*/
            }
            // добавили новые
            foreach (var t in model.SborkaZaiavka)
            {
                context.SborkaZaiavkas.Add(new SborkaZaiavka
                {
                    SborkaId = Convert.ToInt32(Zaiavka.Id),
                    ZaiavkaId = t.Key
                });
                context.SaveChanges();
            }
            return Zaiavka;
        }
        private static ZaiavkaViewModel CreateModel(Zaiavka Zaiavka)
        {
            return new ZaiavkaViewModel
            {
                Id = Zaiavka.Id,
                ZaiavkaName = Zaiavka.ZaiavkaName,
                SborkaZaiavka = Zaiavka.SborkaZaiavka.ToDictionary(recCLP => recCLP.SborkaId, recCLP => (recCLP.sborka?.SborkaName))
            };
        }
    }
}
