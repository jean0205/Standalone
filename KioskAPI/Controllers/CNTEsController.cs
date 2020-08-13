using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KioskAPI.Models;

namespace KioskAPI.Controllers
{
    public class CNTEsController : ApiController
    {
        private StandaloneEntities db = new StandaloneEntities();

        // GET: api/CNTEs
        public IQueryable<CNTE> GetCNTE()
        {
            return db.CNTE;
        }

        // GET: api/CNTEs/5
        [ResponseType(typeof(CNTE))]
        public IHttpActionResult GetCNTE(int id)
        {
            CNTE cNTE = db.CNTE.Find(id);
            if (cNTE == null)
            {
                return NotFound();
            }

            return Ok(cNTE);
        }
        [ResponseType(typeof(CNTE))]
        public IHttpActionResult GetContribution(int employerNo, int employerSub)
        {
            var contribution = new object();
                using(Models.StandaloneEntities db = new Models.StandaloneEntities())
            {
                contribution = (from d in db.CNTE.Where(p => p.EmployerNo == employerNo && p.EmployerSub == employerSub)
                                select new ViewModels.CNTEViewModel
                                {
                                    Id = d.Id,
                                    EmployerNo = d.EmployerNo,
                                    EmployerSub = d.EmployerSub,
                                    Year = d.Year,
                                    Month = d.Month,
                                    NISNumber = d.NisNumber,
                                    EmployeeName = d.Name,
                                    Frequence=d.Frequence,
                                    WeeksWorked = d.WeekW,
                                    Earnings = d.Earnings,
                                    Contribution = d.Contribution,
                                    Penalties = d.Penalties,
                                    Interest = d.Interest,
                                    Week1 = d.Week1,
                                    Week2 = d.Week2,
                                    Week3 = d.Week3,
                                    Week4 = d.Week4,
                                    Week5 = d.Week5,
                                    RecordDate = d.RecordDate
                                }).ToList();
            }
            return Ok(contribution);
        }

        // PUT: api/CNTEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCNTE(int id, CNTE cNTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNTE.Id)
            {
                return BadRequest();
            }

            db.Entry(cNTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNTEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CNTEs
        [ResponseType(typeof(CNTE))]
        public IHttpActionResult PostCNTE(CNTE cNTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CNTE.Add(cNTE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cNTE.Id }, cNTE);
        }

        // DELETE: api/CNTEs/5
        [ResponseType(typeof(CNTE))]
        public IHttpActionResult DeleteCNTE(int id)
        {
            CNTE cNTE = db.CNTE.Find(id);
            if (cNTE == null)
            {
                return NotFound();
            }

            db.CNTE.Remove(cNTE);
            db.SaveChanges();

            return Ok(cNTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNTEExists(int id)
        {
            return db.CNTE.Count(e => e.Id == id) > 0;
        }
    }
}