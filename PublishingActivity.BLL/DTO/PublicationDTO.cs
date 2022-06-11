namespace PublishingActivity.BLL.DTO
{
    public class PublicationDTO
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public string ProfessorName { get; set; }

        public string Subject { get; set; }

        public string CoAuthors { get; set; }

        public string LocationAndDate { get; set; }

        public string Pages { get; set; }

        public int Year { get; set; }
    }
}
