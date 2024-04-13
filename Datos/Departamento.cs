using System;
using System.Collections.Generic;

namespace Datos;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Asociado> Asociados { get; set; } = new List<Asociado>();
}
