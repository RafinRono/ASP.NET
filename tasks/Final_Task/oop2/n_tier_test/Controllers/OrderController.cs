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
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/order/addtocart")]
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
                    OrderService.Add(obj);
                    return Request.CreateResponse(HttpStatusCode.Created, "Added");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/order/removecart")]
        public HttpResponseMessage Remove(ProductDTO obj)
        {
            try
            {
                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
                }
                else
                {
                    OrderService.Remove(obj);
                    return Request.CreateResponse(HttpStatusCode.Created, "Removed item from cart");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/order/showcart")]
        public HttpResponseMessage ShowCart()
        {
            try
            {
                var data = OrderService.ShowCart();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/order/confirm")]
        public HttpResponseMessage Confirm(ProductDTO obj) 
        {
            try
            {
                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
                }
                else
                {
                    OrderService.Confirm();
                    return Request.CreateResponse(HttpStatusCode.Created, "Confirmed");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/order/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
