using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KioskApi.Core.Models;
using KioskApi.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;


namespace KioskApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemittanceController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync( [FromBody] List< Remittance> oModelList)
        {
            Respuesta oResponse = new Respuesta();
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {
                    foreach (Remittance oModel in oModelList)
                    {
                        var remitExist = db.Remittance.Where(p => p.EmployerNo == oModel.EmployerNo && p.EmployerSub == oModel.EmployerSub
                        && p.Year==oModel.Year && p.Month==oModel.Month && p.NisNumber==oModel.NisNumber).FirstOrDefault();
                        Remittance remittance = new Remittance();
                        remittance.EmployerNo = oModel.EmployerNo;
                        remittance.EmployerSub = oModel.EmployerSub;
                        remittance.Year = oModel.Year;
                        remittance.Month = oModel.Month;
                        remittance.NisNumber = oModel.NisNumber;
                        remittance.Name = oModel.Name;
                        remittance.Frequence = oModel.Frequence;
                        remittance.WeekW = oModel.WeekW;
                        remittance.Earnings = oModel.Earnings;
                        remittance.Contribution = oModel.Contribution;
                        remittance.Penalties = oModel.Penalties;
                        remittance.Interest = oModel.Interest;
                        remittance.Week1 = oModel.Week1;
                        remittance.Week2 = oModel.Week2;
                        remittance.Week3 = oModel.Week3;
                        remittance.Week4 = oModel.Week4;
                        remittance.Week5 = oModel.Week5;
                        remittance.RecordDate = oModel.RecordDate;
                        if (remitExist == null)
                        {
                            db.Remittance.Add(remittance);
                        }
                        else 
                        {
                            await UpdateAsync(remitExist);                            
                        }                       
                    }
                    await db.SaveChangesAsync();
                    oResponse.Successfull = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Remittance oModel)
        {
            Respuesta oResponse = new Respuesta();
            try
            {
                using (StandaloneContext db = new StandaloneContext())
                {                   
                    db.Entry(oModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                    oResponse.Successfull = 1;
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
