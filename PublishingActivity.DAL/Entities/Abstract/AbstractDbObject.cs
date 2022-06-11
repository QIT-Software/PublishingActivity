using System.ComponentModel.DataAnnotations;

namespace PublishingActivity.DAL.Entities.Abstract
{
    /// <summary>
    /// abstract object to make everyone's life a bit easier
    /// </summary>
    public abstract class AbstractDbObject
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
