using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGBot.AppServices.Services.CommandServices;
using TGBot.AppServices.Services.ProcessServices;
using TGBot.AppServices.Services.UpdateServices;
using TGBot.AppServices.Services.UserServices;
using TGBot.DataAccess;
using TGBot.Infrastructure.Repository;

namespace TGBot
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
            //Регистрация контекста базы данных
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext>(s => s.GetRequiredService<BaseDbContext>());

            //Регистрация репозитория
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Регистрация клиента Телеграм
            services.AddTelegramBotClient(Configuration);

            //Регистрация сервисов
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IUpdateService, UpdateService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers().
                AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }).AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
