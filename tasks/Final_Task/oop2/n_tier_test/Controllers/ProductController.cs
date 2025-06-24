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
    public class ProductController : ApiController
    {

        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ProductService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[HttpGet]
        //[Route("api/product/all")]
        //public HttpResponseMessage Get()
        //{
        //    var data = ProductService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage Create(ProductDTO obj)
        {
            if (obj == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
            }
            else
            {
                ProductService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.Created, "Added");
            }
            
        }

        [HttpPut]
        [Route("api/product/update")]
        public HttpResponseMessage Update(ProductDTO obj)
        {
            if (obj == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
            }
            else
            {
                ProductService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.Continue, "Updated");
            }

        }

        [HttpDelete]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            ProductService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

    }
}
