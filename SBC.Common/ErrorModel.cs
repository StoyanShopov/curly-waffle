namespace SBC.Common
{
    using System.Net;

    public class ErrorModel
    {
        public ErrorModel(HttpStatusCode status) => this.Status = status;

        public ErrorModel(HttpStatusCode status, string errors)
        {
            this.Status = status;
            this.Errors = new { General = new[] { errors } };
        }

        public ErrorModel(HttpStatusCode status, object errors)
        {
            this.Status = status;
            this.Errors = errors;
        }

        public HttpStatusCode Status { get; set; }

        public object Errors { get; set; }
    }
}
