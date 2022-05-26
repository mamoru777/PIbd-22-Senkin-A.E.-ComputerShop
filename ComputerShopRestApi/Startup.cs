using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopContracts.StorageContracts;
using ComputerShopDataBaseImplement.Implements;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopBuisnessLogic.BuisnessLogic;


namespace ComputerShopRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISborkaStorage, SborkaStorage>();
            services.AddTransient<IComplectStorage, ComplectStorage>();
            services.AddTransient<IZakupkaStorage, ZakupkaStorage>();
            services.AddTransient<IPostavshikStorage, PostavshikStorage>();
            services.AddTransient<IPolTechnicStorage, PolTechnicStorage>();
            services.AddTransient<IZaiavkaStorage, ZaiavkaStorage>();
            services.AddTransient<IPostavkaStorage, PostavkaStorage>();
            services.AddTransient<ISborkaLogic, SborkaLogic>();
            services.AddTransient<IComplectLogic, ComplectLogic>();
            services.AddTransient<IZakupkaLogic, ZakupkaLogic>();
            services.AddTransient<IPostavshikLogic, PostavshikLogic>();
            services.AddTransient<IPolTechnicLogic, PolTechnicLogic>();
            services.AddTransient<IZaiavkaLogic, ZaiavkaLogic>();
            services.AddTransient<IPostavkaLogic, PostavkaLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComputerShopRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComputerShopRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
