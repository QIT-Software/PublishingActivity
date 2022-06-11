using System;
using PublicationActivity.Shared;

namespace PublishingActivity.BLL.DTO
{
    public class PublicationStatusTrackerDTO
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public PublicationDTO Publication { get; set; }

        public DateTime Date { get; set; }

        public PublicationStatus Status { get; set; }
    }
}
