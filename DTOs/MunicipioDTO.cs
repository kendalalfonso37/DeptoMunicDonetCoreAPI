using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosAPI.DTOs
{
    public class MunicipioDTO : EntityDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string CNRMunicipio { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public DepartamentoDTO Departamento { get; set; }

    }
}
