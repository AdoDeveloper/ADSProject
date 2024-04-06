using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Interfaces
{
    public interface IGrupo
    {
        int AgregarGrupo(Grupo grupo);
        int ActualizarGrupo(int idGrupo, Grupo grupo);
        bool EliminarGrupo(int idGrupo);
        List<Grupo> ObtenerTodosLosGrupos();
        Grupo ObtenerGrupoPorID(int idGrupo);
    }
}