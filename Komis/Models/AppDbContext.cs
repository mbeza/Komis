using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) //przekazanie opcji do typu podstawowego 
        {
        }

        //okreslenie które typy mają być odzwierciedlone w bazie danych

        public DbSet<Samochod> Samochody { get; set; }

    }
}
