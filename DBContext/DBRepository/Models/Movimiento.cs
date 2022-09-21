using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.DBRepository.Models
{
    [Table("Movimiento")]
    public partial class Movimiento
    {
        [Key]
        [Column("MovimientoID")]
        public int MovimientoId { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string NumeroCuenta { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string TipoMovimiento { get; set; } = null!;
        [Column(TypeName = "decimal(10, 4)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public decimal Saldo { get; set; }

        [ForeignKey("NumeroCuenta")]
        [InverseProperty("Movimientos")]
        public virtual Cuentum NumeroCuentaNavigation { get; set; } = null!;
    }
}
