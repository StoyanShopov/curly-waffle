namespace SBC.Data.Models
{
    public class LanguageCoach
    {
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
