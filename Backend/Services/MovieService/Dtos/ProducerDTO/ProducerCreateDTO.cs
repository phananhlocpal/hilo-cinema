﻿using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.ProducerDTO
{
    public class ProducerCreateDTO
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        public byte[] Img { get; set; }
    }
}