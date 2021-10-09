using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOECSREP.POC.Certificates.Data;
using MOECSREP.POC.Certificates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Certificates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly MDEDBContext _context;
        public CertificateController(MDEDBContext context)
        {
            _context = context;
        }
               
        // GET: api/certificate/5
        [HttpGet("{id}", Name = "CertificateById")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MOECSREP.POC.Certificates.Models.Certificate>>> GetCertificateByEducatorId(int id)
        {
            // get the list of certificates for a particular educator.
            var certificateList = _context.Certificates.Where(cert => cert.EducatorID == id).OrderByDescending(a => a.IssueDate).ToList();    
            // the list should not be empty
            if (certificateList != null)
            {
                return certificateList;               
            }

            return NotFound();
        }
    }
}
