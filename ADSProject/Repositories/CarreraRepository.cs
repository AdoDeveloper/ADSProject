using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarreras = new List<Carrera>
        {
            new Carrera
            {
                IdCarrera = 1,
                Codigo = "i04",
                Nombre = "Ingeniería en Sistemas Commputacionales"
            },
            new Carrera
            {
                IdCarrera = 2,
                Codigo = "i03",
                Nombre = "Ingeniería Industrial"
            }
        };

        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarreras[indice] = carrera;
                return idCarrera;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                if (lstCarreras.Count > 0)
                {
                    carrera.IdCarrera = lstCarreras.Last().IdCarrera + 1;
                }

                lstCarreras.Add(carrera);

                return carrera.IdCarrera;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarreras.RemoveAt(indice);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Carrera ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                Carrera carrera = lstCarreras.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);
                return carrera;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Carrera> ObtenerTodasLasCarreras()
        {
            try
            {
                return lstCarreras;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
