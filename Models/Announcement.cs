using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityServiceApp2.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(20)]
        public string Priority { get; set; }

        public DateTime DatePublished { get; set; }

        public bool IsActive { get; set; }
    }
}