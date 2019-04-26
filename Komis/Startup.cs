using Komis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Startup
    {
        public IConfiguration Configuration { get; } //zawiera informacje odczytane przez klasę program

        public Startup(IConfiguration configuration) // przekazywanie konfiguracji podczas uruchamiania, przez wstrzyknięcie konstruktora konfiguracji
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddTransient<ISamochodRepository, MockSamochodRepository>(); // tam gdzie bedzie wymagany interfejs ISamochodRepository, zostanie wstrzykniete MockSamochodRepository
            services.AddTransient<ISamochodRepository, SamochodRepository>();
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
