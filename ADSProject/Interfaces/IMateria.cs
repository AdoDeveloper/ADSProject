using System.Collections.Generic;
using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IMateria
    {
        int AgregarMateria(Materia materia);

        int ActualizarMateria(int idMateria, Materia materia);

        bool EliminarMateria(int idMateria);

        List<Materia> ObtenerTodasLasMaterias();

        Materia ObtenerMateriaPorID(int idMateria);
    }
}
