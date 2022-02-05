using DbDataLibrary.Models.Entities;
using MatBlazor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmBlazor.Extensions;
using OneTrackerWeb.Services;
using OneTrackerWeb.ViewModel;
using Syncfusion.Blazor;

namespace OneTrackerWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            string dbConn2 = configuration.GetValue<string>("Syncfusion:BlazorKey");
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(dbConn2);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSyncfusionBlazor();
            /// Generyczny servis do kontaktu z baza danych
            //services.AddScoped(typeof(IDataStore<>), typeof(GenericDataStore<>));

            services.AddSingleton<GenericDataStore<Department>>();
            services.AddSingleton<CloseProjectsDataStore>();
            services.AddSingleton<TeamsDataStore>();
            services.AddSingleton<DevelopersDataStore>();
            services.AddSingleton<ProjectDataStore>();
            ///Matblazor dla dotatkowych kontrolek
            services.AddMatBlazor();

            ///Matblazor Snackbar
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.Position = MatToastPosition.BottomFullWidth;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 4000;
            });

            ///Add extenstion to use MVVM desing pattern
            services.AddMvvm();
            services.AddSingleton<DepartmentViewModel>();
            services.AddSingleton<TeamsViewModel>();
            services.AddSingleton<DevelopersViewModel>();
            services.AddSingleton<OpenProjectViewModel>();
            services.AddSingleton<CloseProjectsViewModel>();
            services.AddSingleton<AddProjectViewModel>();
            services.AddSingleton<ChartsViewModel>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add your Syncfusion license key for Blazor platform with corresponding Syncfusion NuGet version referred in project. For more information about license key see https://help.syncfusion.com/common/essential-studio/licensing/license-key.
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Add your license key here");

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