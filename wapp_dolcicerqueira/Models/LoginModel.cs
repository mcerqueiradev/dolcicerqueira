﻿using System.ComponentModel.DataAnnotations;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        public Users UserModel { get; set; }     
    }
}
