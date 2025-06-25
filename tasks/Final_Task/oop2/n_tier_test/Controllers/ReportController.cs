using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using BLL.Services;

namespace n_tier_test.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/report/revenue")]
        public HttpResponseMessage ExportTotalRevenueXml()
        {
            try
            {
                var xml = ReportService.GetTotalRevenueXml();
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                };
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/report/topproduct")]
        public HttpResponseMessage ExportTopProductsXml()
        {
            try
            {
                var xml = ReportService.GetTopSellingProductsXml();
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                };
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
