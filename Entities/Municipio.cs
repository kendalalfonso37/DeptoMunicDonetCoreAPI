﻿using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosAPI.Entities
{
    public class Municipio : Entity
    {
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }
        public string CNRMunicipio { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public Departamento Departamento { get; set; }

    }
}
