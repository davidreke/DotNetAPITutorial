using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesApi.Models;
using QuotesApi.Controllers;
using QuotesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace QuotesApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
<<<<<<< HEAD
            services.AddDbContext<QuotesDbContext>(option => option.UseSqlServer(@"Data Source =DESKTOP-99F9QST;Initial Catalog=QuotesDb;"));
=======
            services.AddDbContext<QuotesDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuotesDb;"));
            // his code looks like  services.AddDbContext<QuotesDbContext>(option => option.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=QuotesDb;"));
>>>>>>> 05e21c5e188bc6f999382527f1b46a77f1176e91
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, QuotesDbContext quotesDbContext )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            quotesDbContext.Database.EnsureCreated();
            app.UseMvc();
        }
    }
}
