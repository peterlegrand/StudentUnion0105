using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.SQLRepositories;

namespace StudentUnion0105
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
            services.AddDbContextPool<SuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SuConnectionString")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<SuUser, IdentityRole>().AddEntityFrameworkStores<SuDbContext>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Classification", policy => policy.RequireClaim("Menu", "Classification"));
                options.AddPolicy("Roles", policy => policy.RequireClaim("Menu", "Roles"));
            });
            services.AddTransient<IClassificationRepository, SQLClassificationRepository>();
            services.AddTransient<IClassificationVMRepository, SQLClassificationVMRepository>();
            services.AddTransient<IClassificationLevelVMRepository, SQLClassificationLevelVMRepository>();
            services.AddTransient<IClaimRepository, SQLClaimRepository>();
            services.AddTransient<IClassificationStatusRepository, SQLClassificationStatusRepository>();
            services.AddTransient<IClassificationLanguageRepository, SQLClassificationLanguageRepository>();
            services.AddTransient<IClassificationLevelRepository, SQLClassificationLevelRepository>();
            services.AddTransient<IClassificationLevelLanguageRepository, SQLClassificationLevelLanguageRepository>();
            services.AddTransient<ILanguageRepository, SQLLanguageRepository>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/User/login");
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
 }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
