namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;

    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var result = new ApiResult
            {
              
                Message = "Demo data Collection Retrieved",
                Value = new List<string> { "demo_Object_1", "demo_Object_2", "demo_Object_3" },
            };

            return this.Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById()
        {
           
            var result = new ApiResult()
            {
                Message = "Demo data Collection Retrieved",
                Value = new { Value = "demo_Object_1" },
            };

            return this.Ok(result);
        }
    }
}
