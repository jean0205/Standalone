using KioskApi.Core.Models.Response;
using KioskAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KioskApi.Core.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionController : ControllerBase
    {

        [HttpGet("getContribution/{employerNo}-{employerSub}")]
        public IActionResult GetID(int employerNo, int employerSub)
        {
            Respuesta oResponse = new Respuesta();
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    var cnte = db.Cnte.Where(p => p.EmployerNo == employerNo && p.EmployerSub == employerSub).ToList();
                    oResponse.Successfull = 1;
                    oResponse.Data = cnte;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }
       
    }
}
