using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.DBRepository.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        [Key]
        [StringLength(15)]
        [Unicode(false)]
        public string NumeroCuenta { get; set; } = null!;
        [Column("ClienteID")]
        public int ClienteId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string TipoCuenta { get; set; } = null!;
        [Column(TypeName = "decimal(10, 4)")]
        public decimal SaldoInicial { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;

        [ForeignKey("ClienteId")]
        [InverseProperty("Cuenta")]
        public virtual Cliente Cliente { get; set; } = null!;
        [InverseProperty("NumeroCuentaNavigation")]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
