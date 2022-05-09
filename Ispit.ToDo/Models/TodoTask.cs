using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.ToDo.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public bool Status { get; set; }

        [ForeignKey("TodolistId")]
        public Todolist Todolist { get; set; }
        public int TodolistId { get; set; }
        
    }
}
