using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADSProject.Controllers
{
    [Route("api/materias/")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateria materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriasController(IMateria materia)
        {
            this.materia = materia;
        }

        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materia nuevaMateria)
        {
            try
            {
                int idMateria = this.materia.AgregarMateria(nuevaMateria);
                pCodRespuesta = COD_EXITO;
                pMensajeUsuario = "Materia agregada correctamente";
                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception ex)
            {
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Error al agregar la materia";
                pMensajeTecnico = pCodRespuesta + " || " + ex.Message;
                return StatusCode(500, new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
        }

        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, [FromBody] Materia materiaActualizada)
        {
            try
            {
                int contador = this.materia.ActualizarMateria(idMateria, materiaActualizada);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Materia actualizada correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se pudo encontrar la materia especificada";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception ex)
            {
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Error al actualizar la materia";
                pMensajeTecnico = pCodRespuesta + " || " + ex.Message;
                return StatusCode(500, new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
        }

        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Materia eliminada correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se pudo encontrar la materia especificada";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception ex)
            {
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Error al eliminar la materia";
                pMensajeTecnico = pCodRespuesta + " || " + ex.Message;
                return StatusCode(500, new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
        }

        [HttpGet("obtenerMateriaPorID/{idMateria}")]
        public ActionResult<Materia> ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia materia = this.materia.ObtenerMateriaPorID(idMateria);
                if (materia != null)
                {
                    return Ok(materia);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontró la materia especificada";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Error al obtener la materia";
                pMensajeTecnico = pCodRespuesta + " || " + ex.Message;
                return StatusCode(500, new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
        }

        [HttpGet("obtenerMaterias")]
        public ActionResult<List<Materia>> ObtenerMaterias()
        {
            try
            {
                List<Materia> lstMaterias = this.materia.ObtenerTodasLasMaterias();
                return Ok(lstMaterias);
            }
            catch (Exception ex)
            {
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Error al obtener las materias";
                pMensajeTecnico = pCodRespuesta + " || " + ex.Message;
                return StatusCode(500, new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
        }
    }
}
