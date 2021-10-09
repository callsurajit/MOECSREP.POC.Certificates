using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Certificates.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }
        public int EducatorID { get; set; }
        public string ApplicationID { get; set; }
        public string CertificateNumber { get; set; }
        public string LicenseType { get; set; }
        public string Status { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
