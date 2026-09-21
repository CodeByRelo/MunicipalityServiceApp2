using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityServiceApp2.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(500)]
        public string AttachmentPath { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime DateReported { get; set; }
    }
}