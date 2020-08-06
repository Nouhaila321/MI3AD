using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using UserDataAccess;


namespace WebAPIDemo.Controllers
{
    
    public class UserstController : ApiController
    {

        public HttpResponseMessage Get (int id)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                var entity = entities.Users.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with ID = " + id.ToString() + " not found");
                }
            }
        }
        
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name; 
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                var entity = entities.Users.FirstOrDefault(e => e.EMAIL == username);
                int id_user = entity.ID;

                return Request.CreateResponse(HttpStatusCode.OK,
                    entities.RDVs.Where(e => e.ID_User == id_user).ToList());   
            }
        }
             
        public HttpResponseMessage Post ([FromBody]User U)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    entities.Users.Add(U);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, U);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + U.ID.ToString());
                    return message;

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

        public HttpResponseMessage Delete (int id)
        {
            try {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.Users.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with ID = " + id.ToString() + " not found");

                    }
                    else
                    {
                        entities.Users.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            } catch (Exception e) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
        }
        
        public HttpResponseMessage Put (int id, [FromBody] User U)
        {
            try {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.Users.FirstOrDefault(e => e.ID == id);
                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with ID = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.NOM = U.NOM;
                        entity.PRENOM = U.PRENOM;
                        entity.PHONE = U.PHONE;
                        entity.EMAIL = U.EMAIL;
                        entity.TEL = U.TEL;
                        
                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }
                }
            } catch (Exception e) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}

