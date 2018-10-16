using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gadi.Business.Extensions;
using Gadi.Business.Interfaces;
using Gadi.Business.Models;
using Gadi.Common.Dto;
using Gadi.Data.Interfaces;

namespace Gadi.Business.Services
{
    public partial class PersonnelBusinessService : IPersonnelBusinessService
    {
        private readonly IPersonnelDataService _dataService;
        //protected IDocumentsBusinessService DocumentsBusinessService;
        private readonly IMapper _mapper;
        public PersonnelBusinessService(IPersonnelDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
           // DocumentsBusinessService = documentsBusinessService;
        }

        #region Create
        public async Task<ValidationResult<Personnel>> CreatePersonnel(Personnel personnel)
        {
            var validationResult = await PersonnelAlreadyExists(personnel.Mobile, personnel.Email);
            if (!validationResult.Succeeded)
            {
                return validationResult;
            }
            try
            {
                var personnelData = _mapper.Map<Data.Entities.Personnel>(personnel);
                await _dataService.CreateAsync(personnelData);
                //Send Confirmation Email to Personnel and Seller
                //if (personnel. != null && personnel.IsSeller.Value)
                //SendSellerEmail(personnel);

                validationResult.Entity = personnel;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        public async Task<ValidationResult<Document>> UploadDocument(Document document, int personnelId)
        {
            var validationResult = new ValidationResult<Document>();
            try
            {
                var documentData = _mapper.Map<Document>(document);
                //var result = await DocumentsBusinessService.CreateDocument(documentData);
                //if (result.Succeeded)
                //{
                //    var personnelDocument = new PersonnelDocument
                //    {
                //        PersonnelId = personnelId,
                //        DocumentDetailId = result.Entity.DocumentId // Just Confirm what should pass to documentdetailid
                //    };
                //    var personnelDocumentData = _mapper.Map<Data.Entities.PersonnelDocument>(personnelDocument);
                //    await _dataService.CreateAsync(personnelDocumentData);
                //}
                validationResult.Entity = document;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }
        #endregion

        #region Retrieve

        public async Task<bool> CanDeletePersonnel(int PersonnelId)
        {
            return await Task.FromResult(true);
        }

        public async Task<Personnel> RetrievePersonnel(int centreId, int personnelId)
        {
            var personnels = await _dataService.RetrieveAsync<Data.Entities.Personnel>(a => a.PersonnelId == personnelId);
            var personnel = _mapper.MapToList<Personnel>(personnels);
            return personnel.FirstOrDefault();
        }

        public async Task<ValidationResult<Personnel>> RetrievePersonnel(int personnelId)
        {
            var personnelData = await _dataService.RetrieveByIdAsync<Data.Entities.Personnel>(personnelId);
            var personnel = _mapper.Map<Personnel>(personnelData);
            if (personnel != null)
            {
                var validationResult = new ValidationResult<Personnel>
                {
                    Entity = personnel,
                    Succeeded = true
                };
                return validationResult;
            }

            return new ValidationResult<Personnel>
            {
                Succeeded = false,
                Errors = new[] { string.Format("No Worker found with Id: {0}", personnelId) }
            };
        }

        public async Task<PagedResult<Personnel>> RetrievePersonnels(List<OrderBy> orderBy = null, Paging paging = null)
        {
            var personnel = await _dataService.RetrievePagedResultAsync<Data.Entities.Personnel>(e => true, orderBy, paging);
            return _mapper.MapToPagedResult<Personnel>(personnel);
        }

        public async Task<ValidationResult<Personnel>> PersonnelAlreadyExists(string mobileNumber, string email = null)
        {
            var personnelData = await _dataService.RetrieveAsync<Data.Entities.Personnel>(a => a.Mobile == mobileNumber);
            
            if (!string.IsNullOrEmpty(email))
                personnelData = await _dataService.RetrieveAsync<Data.Entities.Personnel>(a => a.Email.ToLower() == email.ToLower());
            var alreadyExists = personnelData.Any();
            //var personnels = _mapper.MapToList<Personnel>(personnelData);
            return new ValidationResult<Personnel>
            {
                Succeeded = !alreadyExists,
                Errors = alreadyExists ? new List<string> { "User already exists." } : null,
                Message = "User already exists."
            };
        }

        public async Task<PagedResult<Personnel>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null)
        {
            var personnels= await _dataService.RetrievePagedResultAsync<Data.Entities.Personnel>(a =>
                    a.Mobile.ToLower().Contains(term.ToLower())
                    || a.Forenames.Replace(" ", "").ToLower().Contains(term.ToLower())
                    || a.Surname.Replace(" ", "").ToLower().Contains(term.ToLower())
                , orderBy, paging);
            return _mapper.MapToPagedResult<Personnel>(personnels);
        }


        public async Task<Personnel> RetrievePersonnel(string userId)
        {
            var personnels = await _dataService.RetrieveAsync<Data.Entities.Personnel>(e => e.UserId == userId);
            var personnel = _mapper.MapToList<Personnel>(personnels);
            return personnel.FirstOrDefault();
        }

        #endregion

        #region Update

        public async Task<ValidationResult<Personnel>> UpdatePersonnel(Personnel personnel)
        {
            var validationResult = new ValidationResult<Personnel>();
            try
            {
                var personnelData = _mapper.Map<Personnel>(personnel);
                await _dataService.UpdateAsync(personnelData);
                validationResult.Entity = personnel;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        #endregion

        #region Delete

        public async Task<bool> DeletePersonnel(int id)
        {
            try
            {
                await _dataService.DeleteByIdAsync<Data.Entities.Personnel>(id);
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion
    }
}
