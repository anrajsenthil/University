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
using University.Api.Search.Interfaces;
using University.Api.Search.Services;
using Polly;

namespace University.Api.Search
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
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAdmissionService, AdmissionService>();
            services.AddScoped<ICourses, CoursesService>();
            services.AddScoped<IStudent, StudentService>();
            services.AddHttpClient("AdmissionService", config =>
             {
                 config.BaseAddress = new Uri(Configuration["Services:Admission"]);
             });

            services.AddHttpClient("CoursesService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Courses"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));

            services.AddHttpClient("StudentService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Student"]);
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
