using System;
using System.Collections.Generic;

namespace Front.Models
{
    public partial class Transacciones
    {
        public int Id { get; set; }
        public string IdTxBc { get; set; }
        public string Monto { get; set; }
        public int CuentasId { get; set; }

        public Cuentas Cuentas { get; set; }
    }
}
