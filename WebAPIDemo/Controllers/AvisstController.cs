using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;

namespace WebAPIDemo.Controllers
{
    public class AvisstController : ApiController
    {
        public IEnumerable<Aviss> Get()
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                return entities.Avisses.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                var entity = entities.Avisses.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "A with ID = " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody]Aviss A)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    entities.Avisses.Add(A);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, A);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + A.ID.ToString());
                    return message;

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.Avisses.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with ID = " + id.ToString() + " not found");

                    }
                    else
                    {
                        entities.Avisses.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

        public HttpResponseMessage Put(int id, [FromBody] Aviss A)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.Avisses.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Avis with ID = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.NOTE_ACCUEIL = A.NOTE_ACCUEIL;
                        entity.NOTE_DIAG = A.NOTE_DIAG;
                        entity.NOTE_FACIL = A.NOTE_FACIL;
                        entity.NOTE_PROMPATITUDE = A.NOTE_PROMPATITUDE;
                        entity.NOTE_RECOM = A.NOTE_RECOM;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
