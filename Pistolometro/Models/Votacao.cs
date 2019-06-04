using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pistolometro.Models
{
    public class Votacao
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Inicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fim { get; set; }

        public int QuantidadeVotos { get; set; }        

        public string IdUsuario { get; set; }

        public IdentityUser IdentityUser { get; set; }
    }
}
