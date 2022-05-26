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
    public class PostavshikStorage : IPostavshikStorage
    {
        public List<PostavshikViewModel> GetFullList()
        {
            using var context = new ComputerShopDataBase();
            return context.Postavshiks.Select(CreateModel).ToList();

        }
        public List<PostavshikViewModel> GetFilteredList(PostavshikBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            return context.Postavshiks.Include(rec => rec.Sborkas).Include(rec => rec.Complects).Where(rec => rec.Mail == model.Mail && rec.Password == model.Password).Select(CreateModel).ToList();
        }
        public PostavshikViewModel GetElement(PostavshikBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDataBase();
            var postavshik = context.Postavshiks.Include(rec => rec.Sborkas).Include(rec => rec.Complects).FirstOrDefault(rec => rec.Mail == model.Mail || rec.Id == model.Id);
            return postavshik != null ? CreateModel(postavshik) : null;
        }
        public void Insert(PostavshikBindingModel model)
        {
            using var context = new ComputerShopDataBase();
            context.Postavshiks.Add(CreateModel(model, new Postavshik()));
            context.SaveChanges();
        }
        public void Update(PostavshikBindingModel model)
        {
            using var context = new ComputerShopDataBase();
            var postavshik = context.Postavshiks.FirstOrDefault(rec => rec.Id == model.Id);
            if (postavshik == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, postavshik);
            context.SaveChanges();
        }
        public void Delete(PostavshikBindingModel model)
        {
            using var context = new ComputerShopDataBase();
            Postavshik postavshik = context.Postavshiks.FirstOrDefault(rec => rec.Id == model.Id);
            if (postavshik != null)
            {
                context.Postavshiks.Remove(postavshik);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Postavshik CreateModel(PostavshikBindingModel model, Postavshik postavshik)
        {
            postavshik.Login = model.Login;
            postavshik.Mail = model.Mail;
            postavshik.Password = model.Password;
            return postavshik;
        }
        private static PostavshikViewModel CreateModel(Postavshik postavshik)
        {
            return new PostavshikViewModel
            {
                Id = postavshik.Id,
                Login = postavshik.Login,
                Mail = postavshik.Mail,
                Password = postavshik.Password
            };
        }
    }
}
