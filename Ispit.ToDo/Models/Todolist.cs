using Ispit.ToDo.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.ToDo.Models
{
    public class Todolist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }

    }
}
