using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsApp.Dtos.Persons
{
    public class PersonCreateDto
        {
        [Required(ErrorMessage = "El DNI es requerido")]
        [StringLength(13, ErrorMessage = "El DNI debe contener 13 dígitos", MinimumLength = 13)]
        public string DNI { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Los {0} son requeridos")]
        [StringLength(50, ErrorMessage = "los {0} deben tener un mínimo de {2} y máximo de {1} caracteres", MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Display( Name = "Apellidos")]
        [Required(ErrorMessage = "Los {0} son requeridos")]
        [StringLength(50, ErrorMessage = "El Apellido debe contener mínimo {2} y un máximo de {1} caracteres", MinimumLength = 3)]

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

    }
}