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
        [StringLength(15)]
        [Unicode(false)]
        public string Identificacion { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Contrasenia { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;

        [ForeignKey("Identificacion")]
        [InverseProperty("Clientes")]
        public virtual Persona IdentificacionNavigation { get; set; } = null!;
        [InverseProperty("Cliente")]
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
