using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using project.Data.Repositories;
using project.Service.Services;
using project.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using project.Data.Context;
using project.Data.Interfaces;

namespace project.Api
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
             var DefaultDatabase= "server=localhost;database=repositoryWolfgangDb;User ID=sa;password=abc123!@#;";
  
            string connectionString0 = Configuration.GetConnectionString("DefaultDatabase");
             //Database Configuration
            var connectionString1 = Configuration["ConnectionString:Default"];
              var connectionString = Configuration["ConnectionString:DefaultDatabase"];
              if(connectionString == null)
              {
                  connectionString = DefaultDatabase;
              }
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("project.Api"))
            );

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddTransient<IShoppingService,ShoppingService>();

            services.AddControllersWithViews();
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
