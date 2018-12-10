using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CompraGadoItem
    {
        public int Id { get; set; }
        [Required]
        public string Quantidade { get; set; }
        //Foreing Key
        public int CompraGadoId { get; set; }
        //Foreing Key
        public int AnimalId { get; set; }

        public ICollection<Animal> Animais { get; set; }

        public CompraGado CompraGado { get; set; }
    }
}