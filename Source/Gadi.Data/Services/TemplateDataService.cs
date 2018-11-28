using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Data.Entities;
using Gadi.Data.Interfaces;
using System.Configuration;

namespace Gadi.Data.Services
{
    public class TemplateDataService:GadiDataService,ITemplateDataService
    {
        public TemplateDataService(IDatabaseFactory<GadiDatabase> databaseFactory, IGenericDataService<DbContext> genericDataService) : base(databaseFactory, genericDataService)
        {
        }

        public Template RetrieveTemplateDetails(string name)
        {
            using (ReadUncommitedTransactionScope)
            using (var context = _databaseFactory.CreateContext())
            {
                var template = context
                    .Templates
                    .AsNoTracking()
                    .SingleOrDefault(p => p.Name.ToLower() == name.ToLower());

                if (template != null)
                {
                    return new Template
                    {
                        Name = template.Name,
                        FileName = template.FileName,
                        Type = template.Type,
                        FilePath = Path.Combine(ConfigurationManager.AppSettings["TemplateRootFilePath"], template.FileName)
                    };
                }
                return null;

            }
        }
    }
}
