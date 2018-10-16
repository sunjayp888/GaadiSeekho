using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class PersonnelDocument
    {
        public int PersonnelDocumentId { get; set; }
        public int PersonnelId { get; set; }
        public int DocumentDetailId { get; set; }
    }
}
