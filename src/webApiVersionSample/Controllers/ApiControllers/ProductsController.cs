using System.Collections.Generic;
using System.Web.Http;
using webApiVersionSample.Attributes;

namespace webApiVersionSample.Controllers.ApiControllers
{
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        [VersionedRoute("products", 1)]
        public IHttpActionResult Get()
        {
            var model = new
            {
                Products = new List<dynamic>
                {
                    new {Id = 1, Name = "M4 Carbine", Description = "Colt LE6920"},
                    new {Id = 2, Name = "M4 Carbine", Description = "Colt LE6940"},
                    new {Id = 3, Name = "Semi Auto 9mm", Description = "Beretta 92FS"},
                    new {Id = 4, Name = "Semi Auto 45 ACP", Description = "Smith & Wesson M&P"}
                }
            };


            return Ok(model);
        }

        [VersionedRoute("products", 2)]
        public IHttpActionResult GetV2()
        {
            var model = new
            {
                Products = new List<dynamic>
                {
                    new {Id = 1, Name = "M4 Carbine", Description = "Colt LE6920",Price = "100"},
                    new {Id = 2, Name = "M4 Carbine", Description = "Colt LE6940",Price = "100"},
                    new {Id = 3, Name = "Semi Auto 9mm", Description = "Beretta 92FS",Price = "100"},
                    new {Id = 4, Name = "Semi Auto 45 ACP", Description = "Smith & Wesson M&P",Price = "100"}
                }
            };


            return Ok(model);
        }
    }
}