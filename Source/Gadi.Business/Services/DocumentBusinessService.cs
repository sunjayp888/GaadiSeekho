using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Data.Interfaces;

namespace Gadi.Business.Services
{
    public class DocumentBusinessService : IDocumentsBusinessService
    {
        private readonly IDocumentDataService _documentDataService;

        public DocumentBusinessService(IDocumentDataService documentDataService)
        {
            _documentDataService = documentDataService;
        }
        public async Task<ValidationResult<Document>> CreateDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadDocument(Guid documentGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DocumentCategory>> RetrieveDocumentCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult<Document>> RetrieveDocumentByGuid(Guid documentGuid, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult<Document[]>> RetrieveDocuments(int personnelId, Enum.DocumentCategory category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDocument(List<Guid> guid)
        {
            throw new NotImplementedException();
        }
    }
}
