using Komis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISamochodRepository, MockSamochodRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();    //komponent, dzieki ktoremu bedzie mozna wyswietlac wyjatki
            app.UseStatusCodePages();   //wyswietlanie informacji o statusie zadania
            app.UseStaticFiles();       //podlaczanie obslugi plikow statycznych
            app.UseMvcWithDefaultRoute(); 


        }
    }
}
