using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosAPI.Entities
{
    public class Departamento : Entity
    {
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }
        public string CNRDepartamento { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}
