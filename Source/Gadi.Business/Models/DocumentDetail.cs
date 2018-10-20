using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
   public class DocumentDetail
    {
        public int DocumentDetailId { get; set; }
        public Guid DocumentGUID { get; set; }
        public string PersonnelId { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? UpdatedDateUTC { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public string Description { get; set; }
        public DateTime? DownloadedDateUtc { get; set; }
        public DateTime? ApprovedDateUtc { get; set; }
        public DateTime? EmailSentDateUtc { get; set; }
        public bool? RequireApproval { get; set; }
        public string UncPath { get; set; }
        public string RelativePath { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string ClientFileName { get; set; }
        public int? DocumentBatchId { get; set; }
        public virtual DocumentCategory DocumentCategory { get; set; }
        public virtual Product Product { get; set; }
    }
}
