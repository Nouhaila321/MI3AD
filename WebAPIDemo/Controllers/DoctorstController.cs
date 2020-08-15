using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;


namespace WebAPIDemo.Controllers
{
    public class DoctorstController : ApiController
    {
       
        public HttpResponseMessage GetDoctorBySpecialite([FromUri]string specialte = "All")
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                switch (specialte.ToLower())
                {
                    case "All":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Doctors.ToList());
                    case "pediatre":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Doctors.Where( e => e.SPECIALITE.ToLower() == "Pediatre ").ToList() );
                    case "gynecologue":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Doctors.Where(e => e.SPECIALITE.ToLower() == "Gynecologue ").ToList());
                    case "general":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Doctors.Where(e => e.SPECIALITE.ToLower() == "General ").ToList());
                    case "psycologue":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Doctors.Where(e => e.SPECIALITE.ToLower() == "Psycologue ").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "Merci de choisir une specialte parmis la liste");

                }
            }
        }

        /*public HttpResponseMessage GetDoctorByname(String name)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                var entity = entities.Doctors.FirstOrDefault(e => e.NOM == name);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with ID = " + name + " not found");
                }
            }
        }*/
        /*[HttpGet]
        public HttpResponseMessage Specialite()
        { 
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                //.Country.Select(c => c.NameofCountry).ToListAsync();
                //var entity = entities.RDVs.FirstOrDefault(e => e.ID == id);
                var entity = entities.Doctors.Select(e => e.SPECIALITE).ToList();
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with ID = ");

            }
        }*/
        public HttpResponseMessage Post([FromBody]Doctor D)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    entities.Doctors.Add(D);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, D);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + D.ID.ToString());
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
                    var entity = entities.Doctors.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with ID = " + id.ToString() + " not found");

                    }
                    else
                    {
                        entities.Doctors.Remove(entity);
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

        public HttpResponseMessage Put(int id, [FromBody] Doctor D)
        {
            try
            {
                using (USERSDBEntities entities = new USERSDBEntities())
                {
                    var entity = entities.Doctors.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor  with ID = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.NOM = D.NOM;
                        entity.PRENOM = D.PRENOM;
                        entity.SPECIALITE = D.SPECIALITE;
                        entity.EMAIL = D.EMAIL;
                        entity.TEL = D.TEL;
                      
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
