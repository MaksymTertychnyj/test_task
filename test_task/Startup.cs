using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_task.Data.Context;
using test_task.Data.Entities;
using test_task.Repository;
using test_task.Services;

namespace test_task
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test_task", Version = "v1" });
            });
            services.AddDbContext<MyContext>(options => 
                options.UseSqlServer("Data Source=MAKSYM\\SQLEXPRESS;Initial Catalog=Task_test;Connect Timeout=30;Integrated Security=true;"));
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRepository<Account>, Repository<Account>>();
            services.AddScoped<IRepository<Contact>, Repository<Contact>>();
            services.AddScoped<IRepository<Incident>, Repository<Incident>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test_task v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
