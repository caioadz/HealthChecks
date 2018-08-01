using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BeatPulse;

namespace WithBeatPulse
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
            services.AddBeatPulse(setup => {
                setup
                    .AddUrlGroup(new Uri("http://www.google.com"), "Success", "Google")
                    .AddUrlGroup(new Uri("http://localhost:5000/api/Values/Ok"), "Success", "Ok")
                    .AddUrlGroup(new Uri("http://localhost:5000/api/Values/CreatedAt"), "Success", "CreatedAt")
                    .AddUrlGroup(new Uri("http://www.googlezzaa.com"), "Error", "Google")
                    .AddUrlGroup(new Uri("http://localhost:5000/api/Values/NotFound"), "Error", "NotFound")
                    .AddUrlGroup(new Uri("http://localhost:5000/api/Values/InternalServerError"), "Error", "InternalServerError");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
