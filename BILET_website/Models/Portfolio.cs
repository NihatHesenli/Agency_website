﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BILET_website.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]

        public string Description { get; set; }
        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
