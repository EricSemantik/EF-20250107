﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Exercices
{
    public class Adresse
    {
        public int Id { get; set; }
        public string? Rue { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
    }
}
