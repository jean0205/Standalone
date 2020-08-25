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
    public class RateController : ControllerBase
    { 

         [HttpGet("getRates/{period}")]
        public IActionResult GetID(DateTime period)
    {
        Respuesta oResponse = new Respuesta();
        try
        {
            using (StandaloneContext db = new StandaloneContext())
            {
                var rates = db.Rates.Where(p => p.FromDate <= period && p.ToDate>=period).ToList();
                oResponse.Successfull = 1;
                oResponse.Data = rates;
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
