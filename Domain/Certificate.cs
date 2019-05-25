using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Certificate:BaseEntity
    {
        public string CertificateName { get; set; }
        public ICollection<EmployeCertificate> CertificateEmployees { get; set; }

    }
}
