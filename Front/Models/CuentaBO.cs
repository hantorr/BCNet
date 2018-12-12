using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Models
{
    public class CuentaBO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public string CuentaBc { get; set; }
        public int NumeroDoc { get; set; }
        public int Saldo { get; set; }

    }
}
