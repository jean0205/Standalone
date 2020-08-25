using KioskApi.Core.Models;
using KioskApi.Core.Models.Response;
using KioskAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace KioskApi.Core.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("getEmployee/{nisNumber}")]
        public IActionResult GetID(int nisNumber)
        {
            Respuesta oResponse = new Respuesta();
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    var empe = db.Empe.Where(p => p.NisNumber == nisNumber).FirstOrDefault();
                    oResponse.Successfull = 1;
                    oResponse.Data = empe;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }     

        [HttpGet("getPhoto/{fileName}")]
        public IActionResult GetEmployeeImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = @"\\niserver\DATACARD\Photos\";
                string fullPath = filePath + fileName;
                if (System.IO.File.Exists(fullPath))
                {
                    var image = System.IO.File.OpenRead(fullPath);
                    return File(image, "image/jpeg");
                }
                else
                {
                    while (fileName.Length < 14)
                    {
                        fileName = "0" + fileName;
                        fullPath = filePath + fileName;
                        if (System.IO.File.Exists(fullPath))
                        {
                            var image = System.IO.File.OpenRead(fullPath);
                            return File(image, "image/jpeg");
                        }
                    }

                }
            }

            return NotFound();
        }
        
        [HttpGet("xxx/{nisNumber}")]
        public IActionResult Get()
        {
            Respuesta oResponse = new Respuesta();
            oResponse.Successfull = 0;
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    var lst = db.Empe.ToList();
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
       
    }
}
