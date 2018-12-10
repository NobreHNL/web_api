using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CompraGado
    {
        public int Id { get; set; }

        public DateTime DataEntrega { get; set; }
        //Foreing Key
        public int PecuaristaId { get; set; }

        public Pecuarista Pecuarista { get; set; }

        public ICollection<CompraGadoItem> CompraGadoItems { get; set; }
    }
}