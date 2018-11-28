using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Business.Interfaces;
using Gadi.Data.Interfaces;
using HiQPdf;

namespace Gadi.Business.Services
{
    public class TemplateBusinessService : ITemplateBusinessService
    {
        private readonly IPdfService _pdfService;
        private readonly IRazorService _razorService;
        private readonly ITemplateDataService _templateDataService;

        public TemplateBusinessService(IRazorService razorService, IPdfService pdfService,ITemplateDataService templateDataService)
        {
            _pdfService = pdfService;
            _razorService = razorService;
            _templateDataService = templateDataService;
        }

        public byte[] CreatePDF(string jsonString, string templateName)
        {
            try
            {
                string htmlData = CreateText(jsonString, templateName);
                return _pdfService.CreatePDFfromHtml(htmlData);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public byte[] CreatePDFfromPDFTemplate(Dictionary<string, string> formValues, string templateName)
        {
            var templateDetails = _templateDataService.RetrieveTemplateDetails(templateName);
            return _pdfService.CreatePDFfromPDFTemplate(formValues, templateDetails.FilePath);
        }

        public string CreateText(string jsonString, string templateName)
        {
            if (!_razorService.IsTemplateCached(templateName))
            {
                var template = GetTemplateHtml(templateName);
                _razorService.CacheTemplate(templateName, template);
            }
            return _razorService.CreateText(jsonString, templateName);
        }

        public string GetTemplateHtml(string templateName)
        {
            var templateDetails = _templateDataService.RetrieveTemplateDetails(templateName);
            return File.ReadAllText(templateDetails.FilePath);
        }

        public byte[] MergePDF(byte[] pdfFile1, byte[] pdfFile2)
        {
            // create an empty document which will become
            // the final document after merge
            var resultDocument = new PdfDocument();
            Stream stream1 = new MemoryStream(pdfFile1);
            // load the first document to be merged from a file
            var document1 = PdfDocument.FromStream(stream1);
            // load the second document to be merged from a FileStream
            Stream stream2 = new MemoryStream(pdfFile2);
            var document2 = PdfDocument.FromStream(stream2);
            // add the two documents to the result document
            resultDocument.AddDocument(document1);
            resultDocument.AddDocument(document2);
            try
            {
                byte[] pdfBuffer = resultDocument.WriteToMemory();
                return pdfBuffer;
            }
            finally
            {
                // close the result document
                resultDocument.Close();
                // close the merged documents
                // this will also close the pdfStream from which 
                // document 2 was loaded 
                document1.Close();
                document2.Close();
            }
        }
    }
}
