using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Exercices
{
    [Table("customer")]
    [Index(nameof(Email),  IsUnique = true)]
    public class Client
    {
        [Column("id")]
        public int ClientId { get; set; }
        [Column("lastname")]
        [MaxLength(100)]
        public string Nom { get; set; }
        [Column("firstname")]
        [MaxLength(100)]
        public string? Prenom { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [Column("adress_id")]
        public Adresse? Adresse { get; set; }
        
    }
}
