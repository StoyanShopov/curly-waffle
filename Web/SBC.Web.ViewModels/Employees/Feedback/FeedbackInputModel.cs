namespace SBC.Web.ViewModels.Employees.Feedback
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackInputModel
    {
        [Required]
        public int CoachId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
