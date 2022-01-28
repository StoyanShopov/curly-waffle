namespace SBC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Common;
    using SBC.Services;

    using static SBC.Services.DemoService;

    public class DemoController : ApiController
    {

        private readonly DemoService service = new DemoService();

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            return await GenericResponse(service.GetAll());
        }



        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
                Result result;
            if (id == null)
            {
                result = new Tuple<HttpStatusCode, string>
                    (HttpStatusCode.NotFound, "Entity with this id does not exist");
                return await this.GenericResponse(result);
            }

            return await GenericResponse(service.GetById(id));
        }

        [HttpGet]
        [Route("bad")]
        public async Task<IActionResult> Create()
        {
            return await GenericResponse(service.Add(new Person()));
        }

    }
}
