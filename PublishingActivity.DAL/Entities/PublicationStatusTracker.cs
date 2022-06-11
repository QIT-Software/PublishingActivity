using System;
using PublicationActivity.Shared;
using PublishingActivity.DAL.Entities.Abstract;

namespace PublishingActivity.DAL.Entities
{
    public class PublicationStatusTracker : AbstractDbObject
    {
        public virtual Publication Publication { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public PublicationStatus Status { get; set; }
    }
}