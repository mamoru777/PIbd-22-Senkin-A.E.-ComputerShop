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
    public class ComplectStorage : IComplectStorage
    {
        public List<ComplectViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Complects.Include(rec => rec.ComplectPolTechnic).ThenInclude(rec => rec.poltechnic).Include(rec => rec.SborkaComplect).ThenInclude(rec => rec.sborka).Include(rec => rec.postavshik).Include(rec => rec.zakupka).Select(CreateModel).ToList();
        }

        public List<ComplectViewModel> GetFilteredList(ComplectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Complects.Include(rec => rec.ComplectPolTechnic).ThenInclude(rec => rec.poltechnic).Include(rec => rec.SborkaComplect).ThenInclude(rec => rec.sborka).Include(rec => rec.postavshik).Include(rec => rec.zakupka).Include(rec => rec.postavshik).Where(rec => (model.PostavshikId == rec.PostavshikId)/*rec => rec.ComplectName.Contains(model.ComplectName)*/).Select(CreateModel).ToList();
        }

        public ComplectViewModel GetElement(ComplectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var complect = context.Complects.Include(rec => rec.ComplectPolTechnic).ThenInclude(rec => rec.poltechnic).Include(rec => rec.SborkaComplect).ThenInclude(rec => rec.sborka).Include(rec => rec.postavshik).Include(rec => rec.zakupka).Include(rec => rec.postavshik).FirstOrDefault(rec => rec.ComplectName == model.ComplectName || rec.Id == model.Id);
            return complect != null ? CreateModel(complect) : null;
        }

        public void Insert(ComplectBindingModel model)
        {
            using var complect = new ComputerShopDataBase();
            using var transaction = complect.Database.BeginTransaction();
            try
            {
                complect.Complects.Add(CreateModel(model, new Complect()));
                complect.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            
        }

        public void Update(ComplectBindingModel model)
        {
            using var complect = new ComputerShopDataBase();
            using var transaction = complect.Database.BeginTransaction();
            try
            {
                var element = complect.Complects.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                complect.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(ComplectBindingModel model)
        {

            using var complect = new ComputerShopDataBase();
            Complect element = complect.Complects.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                complect.Complects.Remove(element);
                complect.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Complect CreateModel(ComplectBindingModel model, Complect complect)
        {

            complect.PostavshikId = (int)model.PostavshikId;
            complect.ComplectName = model.ComplectName;
            complect.Price = model.Price;
            //model.postavshik.Complects.Add(model);
            return complect;
        }
        private static ComplectViewModel CreateModel(Complect complect)
        {
            return new ComplectViewModel
            {
                Id = complect.Id,
                PostavshikId = complect.PostavshikId,
                ComplectName = complect.ComplectName,
                Price = complect.Price
            };
        }
    }
}
