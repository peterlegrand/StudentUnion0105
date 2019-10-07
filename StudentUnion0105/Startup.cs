using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                options.AddPolicy("Role", policy => policy.RequireClaim("Menu", "Role"));
                options.AddPolicy("Type", policy => policy.RequireClaim("Menu", "Type"));
                options.AddPolicy("Project", policy => policy.RequireClaim("Menu", "Project"));
                options.AddPolicy("Page", policy => policy.RequireClaim("Menu", "Page"));
            });
            services.AddTransient<IClassificationRepository, SQLClassificationRepository>();
            services.AddTransient<IClassificationVMRepository, SQLClassificationVMRepository>();
            services.AddTransient<IClassificationLevelVMRepository, SQLClassificationLevelVMRepository>();
            services.AddTransient<IClaimRepository, SQLClaimRepository>();
            services.AddTransient<IClassificationStatusRepository, SQLClassificationStatusRepository>();
            services.AddTransient<IClassificationLanguageRepository, SQLClassificationLanguageRepository>();
            services.AddTransient<IClassificationLevelRepository, SQLClassificationLevelRepository>();
            services.AddTransient<IClassificationLevelLanguageRepository, SQLClassificationLevelLanguageRepository>();
            services.AddTransient<IClassificationValueRepository, SQLClassificationValueRepository>();
            services.AddTransient<IClassificationValueLanguageRepository, SQLClassificationValueLanguageRepository>();
            services.AddTransient<IContentTypeLanguageRepository, SQLContentTypeLanguageRepository>();
            services.AddTransient<IContentTypeRepository, SQLContentTypeRepository>();
            services.AddTransient<IOrganizationLanguageRepository, SQLOrganizationLanguageRepository>();
            services.AddTransient<IOrganizationRepository, SQLOrganizationRepository>();
            services.AddTransient<IOrganizationStatusRepository, SQLOrganizationStatusRepository>();
            services.AddTransient<IOrganizationTypeLanguageRepository, SQLOrganizationTypeLanguageRepository>();
            services.AddTransient<IOrganizationTypeRepository, SQLOrganizationTypeRepository>();
            services.AddTransient<IPageLanguageRepository, SQLPageLanguageRepository>();
            services.AddTransient<IPageSectionLanguageRepository, SQLPageSectionLanguageRepository>();
            services.AddTransient<IPageSectionTypeLanguageRepository, SQLPageSectionTypeLanguageRepository>();
            services.AddTransient<IPageRepository, SQLPageRepository>();
            services.AddTransient<IPageSectionRepository, SQLPageSectionRepository>();
            services.AddTransient<IPageSectionTypeRepository, SQLPageSectionTypeRepository>();
            services.AddTransient<IPageStatusRepository, SQLPageStatusRepository>();
            services.AddTransient<IPageTypeLanguageRepository, SQLPageTypeLanguageRepository>();
            services.AddTransient<IPageTypeRepository, SQLPageTypeRepository>();
            services.AddTransient<IProjectLanguageRepository, SQLProjectLanguageRepository>();
            services.AddTransient<IProjectRepository, SQLProjectRepository>();
            services.AddTransient<IProcessTemplateFieldLanguageRepository, SQLProcessTemplateFieldLanguageRepository>();
            services.AddTransient<IProcessTemplateFieldRepository, SQLProcessTemplateFieldRepository>();
            services.AddTransient<IProcessTemplateFieldTypeLanguageRepository, SQLProcessTemplateFieldTypeLanguageRepository>();
            services.AddTransient<IProcessTemplateFieldTypeRepository, SQLProcessTemplateFieldTypeRepository>();
            services.AddTransient<IProcessTemplateFlowConditionTypeRepository, SQLProcessTemplateFlowConditionTypeRepository>();
            services.AddTransient<IProcessTemplateFlowConditionLanguageRepository, SQLProcessTemplateFlowConditionLanguageRepository>();
            services.AddTransient<IProcessTemplateFlowConditionRepository, SQLProcessTemplateFlowConditionRepository>();
            services.AddTransient<IProcessTemplateFlowLanguageRepository, SQLProcessTemplateFlowLanguageRepository>();
            services.AddTransient<IProcessTemplateFlowRepository, SQLProcessTemplateFlowRepository>();
            services.AddTransient<IProcessTemplateGroupLanguageRepository, SQLProcessTemplateGroupLanguageRepository>();
            services.AddTransient<IProcessTemplateGroupRepository, SQLProcessTemplateGroupRepository>();
            services.AddTransient<IProcessTemplateLanguageRepository, SQLProcessTemplateLanguageRepository>();
            services.AddTransient<IProcessTemplateRepository, SQLProcessTemplateRepository>();
            services.AddTransient<IProcessTemplateStepFieldRepository, SQLProcessTemplateStepFieldRepository>();
            services.AddTransient<IProcessTemplateStepFieldStatusRepository, SQLProcessTemplateStepFieldStatusRepository>();
            services.AddTransient<IProcessTemplateStepLanguageRepository, SQLProcessTemplateStepLanguageRepository>();
            services.AddTransient<IProcessTemplateStepRepository, SQLProcessTemplateStepRepository>();
            services.AddTransient<IProjectStatusRepository, SQLProjectStatusRepository>();
            services.AddTransient<IContentRepository, SQLContentRepository>();
            services.AddTransient<IContentClassificationValueRepository, SQLContentClassificationValueRepository>();
            services.AddTransient<IContentStatusRepository, SQLContentStatusRepository>();
            services.AddTransient<ISecurityLevelRepository, SQLSecurityLevelRepository>();
            services.AddTransient<IMasterListRepository, SQLMasterListRepository>();
            services.AddTransient<IDataTypeRepository, SQLDataTypeRepository>();
            services.AddTransient<ILanguageRepository, SQLLanguageRepository>();
            services.AddTransient<ICountryRepository, SQLCountryRepository>();
            services.AddTransient<IGetOrganizationStructureRepository, SQLGetOrganizationStructure>();
            services.AddTransient<IGetProjectStructureRepository, SQLGetProjectStructure>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/User/login");
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<SuUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzcyZTMyMmUzME4wa1lJMzBiUUJJTklORnpaZVFIL1RBa3UrUE1PLzAvZWcvNUQ0dUdaekU9");
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
