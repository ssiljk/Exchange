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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Exchange.Application.Queries;
using Exchange.Application.ExternalApis;
using Exchange.Application.Commands;
using Exchange.Application.Repositories;
using Exchange.Infrastructure.EntityFrameworkDataAccess;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Queries;
using Exchange.Infrastructure.ExternalApis;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Commands;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Repositories;


namespace Exchange.Api
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
            //services.AddMvc(options => (solo para MVC no para apis, para apis mejor usar el middleware
            //{
            //    options.Filters.Add(typeof(ExceptionsFilter));
            //    //options.Filters.Add(typeof(ValidateModelAttribute));
            //});
            services.AddControllers();
            services.AddDbContext<Context>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpClient();
            services.AddScoped<ICurrencyQuery, CurrencyQuery>();
            services.AddScoped<IBankApi, BankApi>();
            services.AddScoped<IBuyCurrency, BuyCurrency>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
                //produces
                //{
                //    "type": "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                //    "title": "An error occured while processing your request.",
                //    "status": 500,
                //    "traceId": "|9800749a-43617a92f40fd5f1."
                //}
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
