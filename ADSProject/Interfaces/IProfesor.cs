using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IProfesor
    {
        int AgregarProfesor(Profesor profesor);
        int ActualizarProfesor(int idProfesor, Profesor profesor);
        bool EliminarProfesor(int idProfesor);
        List<Profesor> ObtenerTodosLosProfesores();
        Profesor ObtenerProfesorPorID(int idProfesor);
    }
}