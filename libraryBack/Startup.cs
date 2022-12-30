using library.Core.Utilities.Extensions.connection;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using library.Core.Services.Implementations;
using library.Core.Services.Interfaces;
using library.DataLayer.Repository;

namespace libraryBack
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

            services.AddSingleton<IConfiguration>(  //=================================>  در این قسمت امدم و فایل اپ ستینگ رو به پروژه معرفی کردم
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json")
                    .Build()
            );

            #region Add DbContext

            services.AddApplicationDbContext(Configuration); // ست کردن کانکشن استرینگ
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));//در این قسمت امدم و سرویس ریپوزیتوری رو به برنامم معرفی کردم

            #endregion

            #region Application Services
            //در زیر امدم و سرویسم که برای مدل یوزر ایجاد کردم به برنامم معرفی کردم
            //در زیر گفتم هر جا که اینترفیس یوزر رو صدا زدن که میشه همون ای یوزر سرویسز شما بیا بهش کلاس یوزر سرویسز رو پاس بده

            services.AddScoped<ImenuServices, menuServices>();

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "libraryBack", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "libraryBack v1"));
            }

            app.UseStaticFiles(); // => این باید بزارم تا تصاویر استاتیک رو از
            //wwwroot
            // برام لود کنه و بیاره و گرنه لود نمیکنه اون تصویری که داخل این پوشه هست منظورم و میدل ور اون کار نمیکنه

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
