using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.DBRepository.Models
{
    [Table("Persona")]
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        [Column("PersonaID")]
        public int PersonaId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(15)]
        [Unicode(false)]
        public string Genero { get; set; } = null!;
        public int? Edad { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Direccion { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? Telefono { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string Identificacion { get; set; } = null!;

        [InverseProperty("Persona")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
