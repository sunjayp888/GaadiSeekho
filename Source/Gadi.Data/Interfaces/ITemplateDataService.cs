using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Data.Entities;

namespace Gadi.Data.Interfaces
{
    public interface ITemplateDataService : IGadiDataService
    {
        Template RetrieveTemplateDetails(string name);
    }
}
