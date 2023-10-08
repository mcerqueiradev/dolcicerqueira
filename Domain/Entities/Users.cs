using Microsoft.AspNetCore.Http;
using System;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserBlocked { get; set; }
        public bool UserAdmin { get; set; }
        //public string NameAdmin { get; set; }
        //public string EmailAdmin { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Upload { get; set; }

    }
}
