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
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/product/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage Create(ProductDTO obj)
        {
            try
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/product/update")]
        public HttpResponseMessage Update(ProductDTO obj)
        {
            try
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProductService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
