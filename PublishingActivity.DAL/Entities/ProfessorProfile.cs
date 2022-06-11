using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublishingActivity.DAL.Entities
{
    public class ProfessorProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }

        public ProfessorProfile()
        {
                Publications = new List<Publication>();
        }
    }
}