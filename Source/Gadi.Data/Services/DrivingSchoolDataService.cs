using System.Data.Entity;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Services
{
    public class DrivingSchoolDataService : GadiDataService, IDrivingSchoolDataService
    {
        public DrivingSchoolDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }
    }
}
