using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace TheaterService.Models
{
    public partial class TheaterModel
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        public string? DetailAddress { get; set; }
        public string? Hotline { get; set; }
    }
}
