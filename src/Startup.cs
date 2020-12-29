using System;
using System.Reflection;
using DbUp;
using invert_api.Domains;
using invert_api.Infrastructure;
using invert_api.Repositories;
using invert_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace invert_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MigrateDB();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions((options)=> {
                options.EnableEndpointRouting = false;
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Invert API" });
            });

            // Services
            services.AddScoped(typeof(MessagesService), typeof(MessagesService));
            services.AddScoped(typeof(LoginMessageService), typeof(LoginMessageService));
            services.AddScoped(typeof(BlobService), typeof(BlobService));

            // Domains
            services.AddScoped(typeof(GetMessages), typeof(GetMessages));
            services.AddScoped(typeof(AddOrUpdateMessage), typeof(AddOrUpdateMessage));
            services.AddScoped(typeof(GetLoginMessages), typeof(GetLoginMessages));
            services.AddScoped(typeof(AddOrUpdateLoginMessage), typeof(AddOrUpdateMessage));
            services.AddScoped(typeof(Blob), typeof(Blob));

            // Repositories
            services.AddScoped(typeof(GetMessagesRepository), typeof(GetMessagesRepository));
            services.AddScoped(typeof(UpdateMessageRepository), typeof(UpdateMessageRepository));
            services.AddScoped(typeof(InsertMessageRepository), typeof(InsertMessageRepository));
            services.AddScoped(typeof(GetLoginMessageRepository), typeof(GetLoginMessageRepository));
            services.AddScoped(typeof(UpdateLoginMessagesRepository), typeof(UpdateLoginMessagesRepository));
            services.AddScoped(typeof(InsertLoginMessageRepository), typeof(InsertLoginMessageRepository));
            services.AddScoped(typeof(InsertBlobRepository), typeof(InsertBlobRepository));

            //Infrastructure
            services.AddScoped(typeof(DbContextFactory), typeof(DbContextFactory));


            services.AddControllers(options => options.InputFormatters.Add(new ByteArrayInputFormatter()));

            services.AddCors(o => o.AddPolicy("dev", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Local")
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("dev");
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invert API");
            });

            app.UseMvc();
        }

        private void MigrateDB()
        {
            var connectionString = Configuration.GetConnectionString("Database");
            
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();


            if (!result.Successful)
            {
                throw result.Error;
            }
        }
    }
}
