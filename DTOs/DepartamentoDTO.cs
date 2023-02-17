using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosAPI.DTOs
{
    public class DepartamentoDTO: EntityDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string CNRDepartamento { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
    }
}
