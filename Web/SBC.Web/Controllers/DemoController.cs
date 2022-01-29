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
        public IActionResult GetAll()
        {
            return this.GenericResponse(this.service.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int? id)
        {
            Result result;
            if (id != null)
            {
                return this.GenericResponse(this.service.GetById((int)id));
            }

            result = new Tuple<HttpStatusCode, string>(
                HttpStatusCode.NotFound, "Entity with this id does not exist");
            return this.GenericResponse(result);
        }

        [HttpGet]
        [Route("bad")]
        public IActionResult Create() => this.GenericResponse(this.service.Add(new Person()));
    }
}
