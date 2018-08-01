using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.HealthChecks;
using WithAspNetCoreHealthChecksAndBackgroundTasks.Tasks;

namespace WithAspNetCoreHealthChecksAndBackgroundTasks
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
            services.AddHealthChecks(setup =>
            {
                setup.AddHealthCheckGroup("Success", group =>
                {
                    group
                        .AddUrlCheck("http://www.google.com")
                        .AddUrlCheck("http://localhost:5000/api/Values/Ok")
                        .AddUrlCheck("http://localhost:5000/api/Values/CreatedAt");
                });

                setup.AddHealthCheckGroup("Error", group =>
                {
                    group
                        .AddUrlCheck("http://www.googlezzaa.com")
                        .AddUrlCheck("http://localhost:5000/api/Values/NotFound")
                        .AddUrlCheck("http://localhost:5000/api/Values/InternalServerError");
                });
            });

            services.AddSingleton<IHostedService, DummyTask>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
