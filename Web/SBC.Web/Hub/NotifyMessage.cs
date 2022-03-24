namespace SBC.Web.Infrastructures.Hub
{
    using System.ComponentModel.DataAnnotations;

    public class NotifyMessage
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; }
    }
}