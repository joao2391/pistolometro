﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Pistolometro.Models
{
    public class Votacao
    {

        public int Id { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public int QuantidadeVotos { get; set; }

        public string NomeVencedor { get; set; }

        //public IdentityUser QuemVotou { get; set; }

    }
}
