using System;
using System.Collections.Generic;
using System.Linq;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMaterias = new List<Materia>
        {
            new Materia
            {
                IdMateria = 1,
                NombreMateria = "Matemáticas"
            },
            new Materia
            {
                IdMateria = 2,
                NombreMateria = "Programación"
            }
        };

        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                if (indice != -1)
                {
                    materia.IdMateria = idMateria; // Mantener el ID original
                    lstMaterias[indice] = materia;
                    return idMateria;
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

        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMaterias.Count > 0)
                {
                    materia.IdMateria = lstMaterias.Last().IdMateria + 1;
                }

                lstMaterias.Add(materia);

                return materia.IdMateria;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                int indice = lstMaterias.FindIndex(tmp => tmp.IdMateria == idMateria);
                if (indice != -1)
                {
                    lstMaterias.RemoveAt(indice);
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

        public Materia ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia materia = lstMaterias.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
                return materia;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return lstMaterias;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
