using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n_tier_test.Controllers
{
    public class StudentController : ApiController
    {
        
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = StudentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage Create(StudentDTO obj)
        {
            if (obj == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
            }
            else
            {
                StudentService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.Created, "Added");
            }
            
        }

        [HttpPut]
        [Route("api/student/update")]
        public HttpResponseMessage Update(StudentDTO obj)
        {
            if (obj == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
            }
            else
            {
                StudentService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.Continue, "Added");
            }

        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            StudentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

    }
}
