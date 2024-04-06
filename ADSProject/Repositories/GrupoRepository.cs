using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> lstGrupos = new List<Grupo>
        {
            new Grupo
            {
                IdGrupo = 1,
                IdCarrera = 1,
                IdMateria = 1,
                IdProfesor = 1,
                Ciclo = 1,
                Anio = 2023
            },
            new Grupo
            {
                IdGrupo = 2,
                IdCarrera = 2,
                IdMateria = 2,
                IdProfesor = 2,
                Ciclo = 2,
                Anio = 2023
            }
        };

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                int indice = lstGrupos.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                if (indice != -1)
                {
                    grupo.IdGrupo = idGrupo; // Mantener el ID original
                    lstGrupos[indice] = grupo;
                    return idGrupo;
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

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                if (lstGrupos.Count > 0)
                {
                    grupo.IdGrupo = lstGrupos.Last().IdGrupo + 1;
                }

                lstGrupos.Add(grupo);
                return grupo.IdGrupo;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {

                int indice = lstGrupos.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                if (indice != -1)
                {
                    lstGrupos.RemoveAt(indice);
                    return true;
                }
                else
                {
                    return false; // La materia no se encontró para eliminar
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                // Buscamos y asignamos el objeto grupo
                Grupo grupo = lstGrupos.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);
                return grupo;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                return lstGrupos;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}