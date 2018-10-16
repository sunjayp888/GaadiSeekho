using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Services
{
    public class PersonnelDataService:GadiDataService,IPersonnelDataService
    {
        public PersonnelDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }
    }
}
