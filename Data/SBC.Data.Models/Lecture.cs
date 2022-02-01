namespace SBC.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Lecture : BaseDeletableModel<string>
    {
        public Lecture()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Resources = new HashSet<Resource>();
            this.Courses = new HashSet<CourseLecture>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<CourseLecture> Courses { get; set; }
    }
}
