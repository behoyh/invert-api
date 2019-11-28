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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Invert API" });
            });
            
            services.AddScoped(typeof(MessagesService), typeof(MessagesService));
            services.AddScoped(typeof(GetMessages), typeof(GetMessages));
            services.AddScoped(typeof(AddOrUpdateMessage), typeof(AddOrUpdateMessage));
            services.AddScoped(typeof(GetMessagesRepository), typeof(GetMessagesRepository));
            services.AddScoped(typeof(UpdateMessageRepository), typeof(UpdateMessageRepository));
            services.AddScoped(typeof(InsertMessageRepository), typeof(InsertMessageRepository));
            services.AddScoped(typeof(InteractiveMessagesFactory), typeof(InteractiveMessagesFactory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invert API");
            });

            app.UseMvc();
        }

        private void MigrateDB()
        {
            //var config = new ConfigurationBuilder()
            //  .AddEnvironmentVariables("CUSTOM_")
            //.Build();
            var connectionString = Configuration.GetConnectionString("Master");
            
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            // Do something with result
        }
    }
}
