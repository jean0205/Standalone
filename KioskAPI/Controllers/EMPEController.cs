using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using KioskAPI.Models;

namespace KioskAPI.Controllers
{
    public class EMPEController : ApiController
    {
         [ResponseType(typeof(EMPE))]
        public IHttpActionResult GetByNumber(int nisNumber)
        {           
            var x = new object();
            using (Models.StandaloneEntities db=new Models.StandaloneEntities())
            {
                x = (from d in db.EMPE.Where(p => p.NisNumber == nisNumber)

                     select new ViewModels.EmpeViewModel
                     {
                         Id = d.Id,
                         NisNumber = d.NisNumber,
                         FirstName = d.FirstName,
                         LastName = d.LastName,
                         MaidenName = d.MaidenName,
                         DateOB = d.DateOB,
                         Address = d.Address,
                         Town = d.Town,
                         Parish = d.Parish,
                         Phone = d.Phone,
                         Email1 = d.Email1,
                         Email2 = d.Email2                         
                     }).ToList();
            }
            return Ok(x);
        }


        [HttpGet]
        public HttpResponseMessage GetEmployeeImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = @"\\niserver\DATACARD\Photos\";
                string fullPath = filePath  + fileName;
                if (File.Exists(fullPath))
                {
                    return FindImage(fullPath, fileName);
                }
                else
                {
                    while (fileName.Length < 14)
                    {
                        fileName = "0" + fileName;
                        fullPath = filePath + fileName;
                        if (File.Exists(fullPath))
                        {
                            return FindImage(fullPath, fileName);
                        }
                    }
                   
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        private HttpResponseMessage FindImage(string fullpath, string fileName)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var fileStream = new FileStream(fullpath, FileMode.Open);
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            return response;
        }
       


    }
}
