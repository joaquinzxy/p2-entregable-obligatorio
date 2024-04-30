using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio;

public class Vacunacion
{
    private Vacuna vacuna;
    private DateTime fechaVacunacion;

    public Vacunacion(Vacuna vacuna, DateTime fechaVacunacion)
    {
        this.vacuna = vacuna;
        this.fechaVacunacion = fechaVacunacion;
    }

    public DateTime getFechaVencimiento()
    {
        return this.fechaVacunacion.AddMonths(3);
    }
}