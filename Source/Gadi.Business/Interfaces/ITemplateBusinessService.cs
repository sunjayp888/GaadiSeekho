using System.Collections.Generic;

namespace Gadi.Business.Interfaces
{
    public interface ITemplateBusinessService
    {
        byte[] CreatePDF(string jsonString, string templateName);
        byte[] CreatePDFfromPDFTemplate(Dictionary<string, string> formValues, string templateName);
        string CreateText(string jsonString, string templateName);
    }
}
