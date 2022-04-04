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
    public class PolTechnicStorage : IPolTechnicStorage
    {
        public List<PolTechnicViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.PolTechnics.Include(rec => rec.postavka).Select(CreateModel).ToList();
        }

        public List<PolTechnicViewModel> GetFilteredList(PolTechnicBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.PolTechnics.Include(rec => rec.postavka).Where(rec => rec.PolTechnicName.Contains(model.PolTechnicName)).Select(CreateModel).ToList();
        }

        public PolTechnicViewModel GetElement(PolTechnicBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var PolTechnic = context.PolTechnics.Include(rec => rec.postavka).FirstOrDefault(rec => rec.PolTechnicName == model.PolTechnicName || rec.Id == model.Id);
            return PolTechnic != null ? CreateModel(PolTechnic) : null;
        }

        public void Insert(PolTechnicBindingModel model)
        {
            using var PolTechnic = new ComputerShopDataBase();
            using var transaction = PolTechnic.Database.BeginTransaction();
            try
            {
                PolTechnic.PolTechnics.Add(CreateModel(model, new PolTechnic()));
                PolTechnic.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        public void Update(PolTechnicBindingModel model)
        {
            using var PolTechnic = new ComputerShopDataBase();
            using var transaction = PolTechnic.Database.BeginTransaction();
            try
            {
                var element = PolTechnic.PolTechnics.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                PolTechnic.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(PolTechnicBindingModel model)
        {

            using var PolTechnic = new ComputerShopDataBase();
            PolTechnic element = PolTechnic.PolTechnics.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                PolTechnic.PolTechnics.Remove(element);
                PolTechnic.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static PolTechnic CreateModel(PolTechnicBindingModel model, PolTechnic PolTechnic)
        {

            PolTechnic.PostavkaId = model.PostavkaId;
            PolTechnic.PolTechnicName = model.PolTechnicName;
            PolTechnic.DatePos = model.DatePos;
            return PolTechnic;
        }
        private static PolTechnicViewModel CreateModel(PolTechnic PolTechnic)
        {
            return new PolTechnicViewModel
            {
                Id = PolTechnic.Id,
                PostavkaId = PolTechnic.PostavkaId,
                PolTechnicName = PolTechnic.PolTechnicName,
                DatePos = PolTechnic.DatePos
            };
        }
    }
}
