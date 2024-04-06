using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstProfesores = new List<Profesor>
        {
            new Profesor
            {
                IdProfesor = 1,
                NombresProfesor = "Juan",
                ApellidosProfesor = "Pérez",
                Email = "juan.perez@example.com"
            },
            new Profesor
            {
                IdProfesor = 2,
                NombresProfesor = "María",
                ApellidosProfesor = "García",
                Email = "maria.garcia@example.com"
            }
        };

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                int indice = lstProfesores.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                if (indice != -1)
                {
                    profesor.IdProfesor = idProfesor; // Mantener el ID original
                    lstProfesores[indice] = profesor;
                    return idProfesor;
                }
                else
                {
                    throw new KeyNotFoundException("La materia especificada no existe.");
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (lstProfesores.Count > 0)
                {
                    profesor.IdProfesor = lstProfesores.Max(x => x.IdProfesor) + 1;
                }
                else
                {
                    profesor.IdProfesor = 1;
                }

                lstProfesores.Add(profesor);
                return profesor.IdProfesor;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                int indice = lstProfesores.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesores.RemoveAt(indice);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor profesor = lstProfesores.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                return profesor;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return lstProfesores;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}