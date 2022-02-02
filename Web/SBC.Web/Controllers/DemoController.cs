namespace SBC.Web.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Common;
    using SBC.Services;
    using SBC.Services.Messaging;

    using static SBC.Services.DemoService;

    public class DemoController : ApiController
    {
        private readonly DemoService service = new DemoService();
        private readonly IEmailSender emailSender;

        public DemoController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

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

        // /send
        [HttpGet]
        [Route("send")]
        public async Task<IActionResult> Send()
        {
            ////Send Email Test:
            var from = "sbc.upskill@gmail.com";
            var fromName = "UpSkill";
            var to = "example@gmail.com";
            var subject = "example subject";
            var htmlContent = "<h1>Example</h1>";
            await this.emailSender.SendEmailAsync(from, fromName, to, subject, htmlContent);

            return this.Ok();
        }

        [HttpGet]
        [Route("bad")]
        public IActionResult Create() => this.GenericResponse(this.service.Add(new Person()));
    }
}
