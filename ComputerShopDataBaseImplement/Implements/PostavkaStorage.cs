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
    public class PostavkaStorage : IPostavkaStorage
    {
        public List<PostavkaViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Postavkas.Include(rec => rec.PostavkaZaiavkas).ThenInclude(rec => rec.zaiavka).Select(CreateModel).ToList();
        }

        public List<PostavkaViewModel> GetFilteredList(PostavkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Postavkas.Include(rec => rec.PostavkaZaiavkas).ThenInclude(rec => rec.zaiavka).Where(rec => rec.PostavkaName.Contains(model.PostavkaName)).Select(CreateModel).ToList();
        }

        public PostavkaViewModel GetElement(PostavkaBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDataBase();
            var Postavka = context.Postavkas.Include(rec => rec.PostavkaZaiavkas).ThenInclude(rec => rec.zaiavka).FirstOrDefault(rec => rec.PostavkaName == model.PostavkaName || rec.Id == model.Id);
            return Postavka != null ? CreateModel(Postavka) : null;
        }

        public void Insert(PostavkaBindingModel model)
        {
            using var Postavka = new ComputerShopDataBase();
            using var transaction = Postavka.Database.BeginTransaction();
            try
            {
                Postavka.Postavkas.Add(CreateModel(model, new Postavka()));
                Postavka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        public void Update(PostavkaBindingModel model)
        {
            using var Postavka = new ComputerShopDataBase();
            using var transaction = Postavka.Database.BeginTransaction();
            try
            {
                var element = Postavka.Postavkas.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                Postavka.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(PostavkaBindingModel model)
        {

            using var Postavka = new ComputerShopDataBase();
            Postavka element = Postavka.Postavkas.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                Postavka.Postavkas.Remove(element);
                Postavka.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Postavka CreateModel(PostavkaBindingModel model, Postavka Postavka)
        {

            Postavka.PostavkaName = model.PostavkaName;
            Postavka.PostavkaCreate = model.PostavkaCreate;
            return Postavka;
        }
        private static PostavkaViewModel CreateModel(Postavka Postavka)
        {
            return new PostavkaViewModel
            {
                Id = Postavka.Id,
                PostavkaName = Postavka.PostavkaName,
                PostavkaCreate = Postavka.PostavkaCreate
            };
        }
    }
}
