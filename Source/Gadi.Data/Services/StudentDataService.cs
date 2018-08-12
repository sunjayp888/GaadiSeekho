using System.Data.Entity;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Services
{
    public class StudentDataService : GadiDataService, IStudentDataService
    {
        public StudentDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }
    }
}
