using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;
namespace WebAPIDemo.Controllers
{
    public class RdvtController : ApiController
    {
        public IEnumerable<RDV> Get()
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                return entities.RDVs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                var entity = entities.RDVs.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " RDV with ID = " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody]RDV V)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    entities.RDVs.Add(V);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, V);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + V.ID.ToString());
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
                    var entity = entities.RDVs.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " with ID = " + id.ToString() + " not found");

                    }
                    else
                    {
                        entities.RDVs.Remove(entity);
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

        public HttpResponseMessage Put(int id, [FromBody] RDV V  )
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.RDVs.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " with ID = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.ETAT = V.ETAT;
                        entity.DATER = V.DATER;
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
