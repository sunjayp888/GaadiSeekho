using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class PersonnelCreatedEmail : HtmlEmail
    {
        public string FullName { get; set; }
    }
}
