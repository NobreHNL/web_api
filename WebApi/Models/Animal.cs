using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Preco { get; set; }
    }
}