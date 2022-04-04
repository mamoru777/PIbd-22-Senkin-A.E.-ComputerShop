using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputerShopDataBaseImplement.Models;

namespace ComputerShopDataBaseImplement
{
    public class ComputerShopDataBase :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=SecureSystemDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Complect> Complects { set; get; }
        public virtual DbSet<Sborka> Sborkas { set; get; }
        public virtual DbSet<SborkaComplect> SborkaComplects { set; get; }
        public virtual DbSet<Zakupka> Zakupkas { set; get; }
        public virtual DbSet<PolTechnic> PolTechnics { set; get; }
        public virtual DbSet<Postavka> Postavkas { set; get; }
        public virtual DbSet<Zaiavka> Zaiavkas { set; get; }
        public virtual DbSet<Postavshik> Postavshiks { set; get; }
        public virtual DbSet<PostavkaZaiavka> PostavkaZaiavkas { set; get; }
        public virtual DbSet<SborkaZaiavka> SborkaZaiavkas { set; get; }

    }

    
}
