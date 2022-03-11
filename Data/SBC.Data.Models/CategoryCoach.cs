using SBC.Data.Common.Models;

namespace SBC.Data.Models
{
    public class CategoryCoach
    {
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
