namespace GorevYonetimSistemi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Bekliyor";

        public DateTime Deadline { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }
    }
}