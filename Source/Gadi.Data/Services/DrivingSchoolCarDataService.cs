using System.Data.Entity;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Services
{
    public class DrivingSchoolCarDataService : GadiDataService, IDrivingSchoolCarDataService
    {
        public DrivingSchoolCarDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }
    }
}
