using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EmployeCertificate
    {
        public int EmployeId { get; set; }
        public int CertificateId { get; set; }
        public Employe Employe { get; set; }
        public Certificate Certificate { get; set; }
    }
}
