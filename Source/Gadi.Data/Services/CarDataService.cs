using System.Data.Entity;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Services
{
    public class CarDataService : GadiDataService, ICarDataService
    {
        public CarDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }
    }
}
