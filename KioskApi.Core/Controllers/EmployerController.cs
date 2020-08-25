using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KioskApi.Core.Models;
using KioskApi.Core.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KioskApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oResponse = new Respuesta();
            oResponse.Successfull = 0;
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    var lst = db.Empr.ToList();
                    oResponse.Successfull = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }
        [HttpGet("getEmployer/{employerNo}-{employerSub}")]
        public IActionResult GetID(int employerNo, int employerSub)
        {                       
            Respuesta oResponse = new Respuesta();
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    var empr = db.Empr.Where(p => p.EmployerNo == employerNo && p.EmployerSub == employerSub).FirstOrDefault();
                    oResponse.Successfull = 1;
                    oResponse.Data = empr;
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
