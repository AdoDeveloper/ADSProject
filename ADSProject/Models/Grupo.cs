using System.ComponentModel.DataAnnotations;
using ADSProject.Validations;

namespace ADSProject.Models
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y debe ser mayor a 0")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Anio { get; set; }
    }
}