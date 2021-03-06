using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Business.Contracts;
using Banking.Business.Implementation;
using Banking.Data.Contracts;
using Banking.Data.Implementation;
using BankingWebApi.HealthCheckers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BankingWebApi
{
    public class Startup
    {
        IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHealthChecks()
                .AddCheck<ReadinessHealthCheck>("readiness_health_check");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking web API", Version = "v1" });
            });

            services.AddTransient<ILocalFileProvider, LocalFileProvider>((serviceProvider) => new LocalFileProvider(env.ContentRootPath));
            services.AddTransient<IAccountsDataProvider, AccountsDataProvider>();
            services.AddTransient<ITransactionsDataProvider, TransactionsDataProvider>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransactionService, TransactionService>();

            GlobalAppSettings.BaseUrl = Configuration["AppConfig:BaseUrl"];
            GlobalAppSettings.AccountsPath = Configuration["AppConfig:AccountsPath"];
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
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger/ui";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Banking WebAPI V1");
            });
        }
    }
}
