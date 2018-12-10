using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Pecuarista
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}