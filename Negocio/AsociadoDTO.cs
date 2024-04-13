using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AsociadoDTO
    {
        public int? IdAsociado { get; set; }
        public string? Nombre { get; set; }
        public decimal? Salario { get; set; }
        public Negocio.Departamento? Departamento { get; set; }
    }
}
