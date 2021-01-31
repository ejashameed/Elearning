using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore
{
    public class Startup
    {
        private IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation()
            .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

            services.AddDbContextPool<BookStoreContext>(options =>
                options.UseSqlServer(Configuration["AzureSqlServer:ConnectionString"])
            );

            services.AddScoped<BookRepository, BookRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            //services.AddSingleton(IServiceProvider =>
            // new BlobServiceClient(connectionString:Configuration.GetValue<String>(key:"AzureBlobStorageConnectionString")));

            //services.AddSingleton<IBlobService, BlobService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(name:"Default",pattern:"{Controller=Home}/{action=Index}/{Id?}");
            });
        }
    }
}
