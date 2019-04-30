using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pistolometro.Models
{
    public class Votacao
    {

        public int Id { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public int QuantidadeVotos { get; set; }

        public IdentityUser NomeVencedor { get; set; }

    }
}
