using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ADSProject.Controllers
{
    [Route("api/grupos/")]
    public class GruposController : ControllerBase
    {
        private readonly IGrupo grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public GruposController(IGrupo grupo)
        {
            this.grupo = grupo;
        }

        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                int idGrupo = this.grupo.AgregarGrupo(grupo);
                if (idGrupo > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con éxito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                int contador = this.grupo.ActualizarGrupo(idGrupo, grupo);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con éxito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("obtenerGrupoPorID/{idGrupo}")]
        public ActionResult<Grupo> ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenerGrupoPorID(idGrupo);

                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del grupo";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("obtenerGrupos")]
        public ActionResult<List<Grupo>> ObtenerGrupos()
        {
            try
            {
                List<Grupo> lstGrupos = this.grupo.ObtenerTodosLosGrupos();
                return Ok(lstGrupos);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}