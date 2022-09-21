using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.DBRepository.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        [Key]
        [Column("ClienteID")]
        public int ClienteId { get; set; }
        [Column("PersonaID")]
        public int PersonaId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Contrasenia { get; set; } = null!;
        [Required]
        public bool? Estado { get; set; }

        [ForeignKey("PersonaId")]
        [InverseProperty("Clientes")]
        public virtual Persona Persona { get; set; } = null!;
        [InverseProperty("Cliente")]
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
