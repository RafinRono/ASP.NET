using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        [HttpGet]
        [Route("api/product/{id}/orders")]
        public HttpResponseMessage GetwithOrder(int id)
        {
            try
            {
                var data = ProductService.GetWithOrders(id);
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

        [HttpPost]
        [Route("api/product/import")]
        public async Task<HttpResponseMessage> ImportCsv()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid format." });

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var file = provider.Contents.FirstOrDefault();
                if (file == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "No file uploaded." });

                var fileBytes = await file.ReadAsByteArrayAsync();
                using (var stream = new MemoryStream(fileBytes))
                {
                    var result = ProductService.ImportCsv(stream);

                    if (result)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Products imported successfully." });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Import failed." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
