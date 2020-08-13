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
    //[Authorize]
    public class EMPRController : ApiController
    {
        private StandaloneEntities db = new StandaloneEntities();

        // GET: api/EMPR
        public IQueryable<EMPR> GetEMPR()
        {
            return db.EMPR;
        }

        // GET: api/EMPR/5
        [ResponseType(typeof(EMPR))]
        public IHttpActionResult GetEMPR(int id)
        {
            EMPR eMPR = db.EMPR.Find(id);
            if (eMPR == null)
            {
                return NotFound();
            }

            return Ok(eMPR);
        }
        // GET: api/EMPR/5
        [ResponseType(typeof(EMPR))]
        public IHttpActionResult GetByNumber(int employerNo, int employerSub)
        {           
            var x = new object();
            using (Models.StandaloneEntities db=new Models.StandaloneEntities())
            {
                x = (from d in db.EMPR.Where(p => p.EmployerNo == employerNo && p.EmployerSub== employerSub)

                     select new ViewModels.EmprViewModel
                     {
                         Id = d.Id,
                         EmployerNo = d.EmployerNo,
                         EmployerSub = d.EmployerSub,
                         BusinessName=d.BusinessName,
                         RealName=d.RealName,
                         BusinessAddress=d.BusinessAddress,
                         BusinessTown=d.BusinessTown,
                         BusinesssParish= d.BusinesssParish,
                         RealAddress=d.RealAddress,
                         RealTown=d.RealTown,
                         RealParish=d.RealParish,
                         RealPhone=d.RealPhone,
                         BusinessPhone=d.BusinessPhone,
                         Email1=d.Email1,
                         Email2=d.Email2
                         
                     }).ToList();
            }
            return Ok(x);
        }       

        // PUT: api/EMPR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPR(int id, EMPR eMPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPR.Id)
            {
                return BadRequest();
            }

            db.Entry(eMPR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPRExists(id))
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

        // POST: api/EMPR
        [ResponseType(typeof(EMPR))]
        public IHttpActionResult PostEMPR(EMPR eMPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPR.Add(eMPR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eMPR.Id }, eMPR);
        }

        // DELETE: api/EMPR/5
        [ResponseType(typeof(EMPR))]
        public IHttpActionResult DeleteEMPR(int id)
        {
            EMPR eMPR = db.EMPR.Find(id);
            if (eMPR == null)
            {
                return NotFound();
            }

            db.EMPR.Remove(eMPR);
            db.SaveChanges();

            return Ok(eMPR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public bool EMPRExists(int id)
        {
            return db.EMPR.Count(e => e.Id == id) > 0;
        }


    }
}