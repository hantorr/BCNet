using System;
using System.Collections.Generic;

namespace Front.Models
{
    public partial class Cuentas
    {
        public Cuentas()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public string CuentaBc { get; set; }
        public int NumeroDoc { get; set; }

        public ICollection<Transacciones> Transacciones { get; set; }
    }
}
