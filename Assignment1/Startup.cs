using Assignment1.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Assignment1.Data;
using Assignment1.Data.Implementation;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

namespace Assignment1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredModal();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<IFamilyService, CustomFamilyAPIConsumer>();
            services.AddScoped<BrowserService>();
            services.AddBlazoredModal();
            services.AddSyncfusionBlazor();
            services.AddScoped<IUserService, UserAPIConsumer>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeAdministrator", a =>
                    a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "Administrator"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzM3MDcwQDMxMzgyZTMzMmUzMGI0ZzJrVURKdzluR21ZRjBpNUZpTnlibDE1VTJ3MHc0THNlbDRmNG9EVkE9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}