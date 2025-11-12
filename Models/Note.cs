using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models
{
    public enum PriorityLevel
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }   = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
        public bool IsArchived { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
