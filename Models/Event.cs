using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityServiceApp2.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(20)]
        public string Priority { get; set; }

        public DateTime DateCreated { get; set; }
    }
}