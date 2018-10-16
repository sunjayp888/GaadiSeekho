using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Business.Models;
using DocumentCategory = Gadi.Business.Models.DocumentCategory;


namespace Gadi.Business.Interfaces
{
    public interface IDocumentsBusinessService
    {
        #region Create
        Task<ValidationResult<Document>> CreateDocument(Document document);
        byte[] DownloadDocument(Guid documentGuid);
        #endregion

        #region Retrieve
        Task<IEnumerable<DocumentCategory>> RetrieveDocumentCategoriesAsync();
        Task<ValidationResult<Document>> RetrieveDocumentByGuid(Guid documentGuid, string userId);
        Task<ValidationResult<Document[]>> RetrieveDocuments(int personnelId, Enum.DocumentCategory category);
        #endregion

        #region Delete
        Task<bool> DeleteDocument(List<Guid> guid);
        #endregion
    }
}