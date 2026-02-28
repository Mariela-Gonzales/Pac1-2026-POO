using System.ComponentModel.DataAnnotations; // Importa herramientas para validaciones como [Required], [StringLength]
using System; // Importa tipos básicos de .NET como Guid y DateTime
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos para mapear tablas y columnas de la base de datos

namespace PersonsApp.Entities // Define el espacio de nombres (organiza el proyecto)
{
    [Table("persons")]  // Indica que esta clase se mapea a la tabla "persons" en la base de datos
    public class PersonEntity : BaseEntity
    {
    
        [Required] //Campo obligatorio (no puede ser null)
        [StringLength(13)] // Limita la longitud máxima a 13 caracteres
        [Column("dni")]
        public string DNI { get; set; }

    
        [Required] //Campo obligatorio
        [StringLength(50)]  // Máximo 50 caracteres
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Required] //campo obligatorio
        [StringLength(50)] //maximo 50
        [Column("last_name")]

        public string LastName { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; } // Fecha de nacimiento de la persona No tiene [Required]
        
        // por lo que podría ser opcional dependiendo de la BD
         [Column ("gender")]
        public string Gender { get; set; }   // Género de la person
    
    }
}








//using System.ComponentModel.DataAnnotations;

// namespace PersonsApp.Entities
// {
//     public class PersonEntity
//     {
//         [Required(ErrorMessage = "El DNI es requerido")]
//         [StringLength(13, ErrorMessage = "El DNI debe contener 13 dígitos", MinimumLength = 13)]
//         public string DNI { get; set; }

//         [Display(Name = "Nombres")]
//         [Required(ErrorMessage = "Los {0} son requeridos")]
//         [StringLength(50, ErrorMessage = "los {0} deben tener un mínimo de {2} y máximo de {1} caracteres", MinimumLength = 3)]
//         public string FirstName { get; set; }
        
//         [Display( Name = "Apellidos")]
//         [Required(ErrorMessage = "Los {0} son requeridos")]
//         [StringLength(50, ErrorMessage = "El Apellido debe contener mínimo {2} y un máximo de {1} caracteres", MinimumLength = 3)]

//         public string LastName { get; set; }
//         public DateTime BirthDate { get; set; }
//         public string Gender { get; set; }

//     }
// }