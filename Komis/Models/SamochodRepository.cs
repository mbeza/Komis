using System.Collections.Generic;
using System.Linq;

namespace Komis.Models
{
    public class SamochodRepository : ISamochodRepository
    {
        private readonly AppDbContext _appDbContext;    //tworzenie dostepu do AppDbContext

        public SamochodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Samochod PobierzSamochodOId(int samochodId)
        {
            return _appDbContext.Samochody.FirstOrDefault(s => s.Id == samochodId);
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return _appDbContext.Samochody;
        }
    }
}
