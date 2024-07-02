﻿using StayInAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Customer
{
    public class CustomerDto
    {

        public string? CustomerId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
