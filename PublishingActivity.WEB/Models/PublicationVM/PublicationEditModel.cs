using System.ComponentModel.DataAnnotations;

namespace PublishingActivity.WEB.Models.PublicationVM
{
    public class PublicationEditModel
    {
        public int Id { get; set; }

        [Required]
        public string ProfessorName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string CoAuthors { get; set; }

        [Required]
        public string LocationAndDate { get; set; }

        [Required]
        public string Pages { get; set; }

        [Required]
        public int Year { get; set; }
    }
}