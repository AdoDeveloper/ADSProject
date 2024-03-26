using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.SignalR;
using System;

namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
            new Estudiante
            {
                IdEstudiante = 1,
                NombresEstudiante = "ADOLFO CORTEZ",
                ApellidosEstudiante = "CORTEZ BARRERA",
                CodigoEstudiante = "CB21I04001",
                CorreoEstudiante = "cb21i04001@usonsonate.edu.sv"
            }
        };
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                // Obtenemos el indice del objeto para actualizar
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                // Procedemos con la actualizacion
                lstEstudiantes[indice] = estudiante;
                return idEstudiante;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Validar si existen datos en la lista, de ser asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad
                if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }

                lstEstudiantes.Add(estudiante);

                return estudiante.IdEstudiante;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                // Obtenemos el indice el objeto a eliminar
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                // Procedemos a eliminar el registro
                lstEstudiantes.RemoveAt(indice);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                // Buscamos y asignamos el objeto estudiante
                Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);
               
                return estudiante;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return lstEstudiantes;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
