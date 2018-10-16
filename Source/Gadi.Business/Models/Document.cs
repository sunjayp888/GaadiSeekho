using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Data.Entities;

namespace Gadi.Business.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int DocumentTypeId { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? DownloadedDateTime { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
