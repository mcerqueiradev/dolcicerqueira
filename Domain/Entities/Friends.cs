using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Friends
    {
        public int Id { get; set; }
        public int UserOne { get; set; }
        public int UserTwo { get; set; }
        public bool Status { get; set; }

        public Users Users { get; set; }
    }
}
