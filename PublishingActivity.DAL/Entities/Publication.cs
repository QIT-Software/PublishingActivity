using System.Collections.Generic;
using PublishingActivity.DAL.Entities.Abstract;

namespace PublishingActivity.DAL.Entities
{
    public class Publication : AbstractDbObject
    {
        public virtual ProfessorProfile Professor { get; set; }

        public string ProfessorName { get; set; }

        public string Subject { get; set; }

        public string CoAuthors { get; set; }

        public string LocationAndDate { get; set; }

        public string Pages { get; set; }

        public int Year { get; set; }

        public virtual ICollection<PublicationStatusTracker> Statuses { get; set; }

        public Publication()
        {
            Statuses = new List<PublicationStatusTracker>();
        }
    }
}