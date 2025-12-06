using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models.DTO
{
    public class RegionDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The Code is Required")]
        [MaxLength(3, ErrorMessage = "The Code lenght must be 3")]
        [MinLength(3, ErrorMessage = "The Code lenght must be 3")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MaxLength(100, ErrorMessage = "The Name lenght maximmumm is 100")]
        public string Name { get; set; }

        // Accept Null
        public string? RegionImageUrl { get; set; }
    }
}
