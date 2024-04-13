using System;
using System.Collections.Generic;

namespace Datos;

public partial class Asociado
{
    public int IdAsociado { get; set; }

    public string? Nombre { get; set; }

    public decimal? Salario { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }
}
