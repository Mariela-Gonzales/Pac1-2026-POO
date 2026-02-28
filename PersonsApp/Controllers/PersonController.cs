using Microsoft.AspNetCore.Mvc;
using PersonsApp.Entities; 
using System.Linq; 
using System.Collections.Generic; 
using System; 


namespace PersonsApp.Controllers
{
    [Route("api/person")] //Ruta base de la API → api/person
    [ApiController]  // Activa validaciones automáticas y comportamiento de API
    public class PersonController : ControllerBase  // Clase controlador (sin vistas)
    {
        private readonly List<PersonEntity> _persons; // Lista en memoria que simula la base de datos
        public PersonController()
        {
            //_persons = new List<PersonEntity>();
            //_persons.Add(new PersonEntity
            //{
                // DNI = "0401200012345",
                //FirstName = "Juan Carlos",
                //LastName = "Pérez",
                //Gender = 'M',
                //BirthDate = DateTime.Parse("01/06/2000")
            //});
            
            _persons = new List<PersonEntity> // Inicializamos la lista con datos de prueba
            {
                new PersonEntity 
                {
                    DNI = "0401200012345",
                    FirstName = "Juan Carlos",
                    LastName = "Pérez",
                    Gender = "M",
                    BirthDate = DateTime.Parse ("01/06/2000")
                },
                new PersonEntity
                {
                    DNI = "0401200012346",
                    FirstName = "María Michelle",
                    LastName = "Lopez Pineda",
                    Gender = "F",
                    BirthDate = DateTime.Parse("15/03/2000")
                },
                new PersonEntity
                {
                    DNI = "0401199812347",
                    FirstName = "Carlos Ismael",
                    LastName = "Rodriguez Mejía",
                    Gender = "M",
                    BirthDate = DateTime.Parse("07/08/1998")
                }
            };
        }

        [HttpGet] //hacer solicitud
        public IActionResult GetAll()
        {
            return Ok(_persons);
        }


        [HttpGet("{dni}")]
        public IActionResult GetOne(string dni)
        {
            var person = _persons.FirstOrDefault(p => p.DNI == dni);  
            return person != null ? Ok(person) : NotFound(new {Message = "Persona no encontrada."});
        }

        [HttpPost] //crear
        public IActionResult Create(PersonEntity person)
        {
            //Console.WriteLine(person);
           // if (string.IsNullOrWhiteSpace(person.DNI))
            //{
            //    return BadRequest(new {Message = "El DNI es requerido"});
            //}

            // if (string.IsNullOrWhiteSpace(person.FirstName))
            // {
            //     return BadRequest(new {Message = "El nombre es requerido"});
            // }

            // if (string.IsNullOrWhiteSpace(person.LastName))
            // {
            //     return BadRequest(new {Message = "Los Apellidos es requerido"});
            // }

            var personExist = _persons.Any(p => p.DNI == person.DNI);

            if (!personExist)
            {
                _persons.Add(person);
                return Created();
            }

            return BadRequest(new {Message = "El DNI ya está registrado"});

        }

        [HttpPut("{dni}")] //actualizar
        public IActionResult Update(string dni, PersonEntity person) //actualizar
        {
            var oldPerson = _persons.FirstOrDefault(p => p.DNI == dni);

            if(oldPerson is null)
            {
                return NotFound(new {Message = "Registro no encontrado"});
            }

            _persons.Remove(oldPerson);
            _persons.Add(person);

            Console.WriteLine($"Persona Actualizada: {person.DNI} - {person.FirstName} {person.LastName}");

            return Ok(new {Message = "Registro editado correctamente..."});
        } 

        [HttpDelete("{dni}")] //eliminar
        public IActionResult Delete(string dni)
        {
            var person = _persons.FirstOrDefault(p => p.DNI == dni);

            if (person is null)
            {
                return NotFound(new { Message = "Registro no encontrado" });
            }

            _persons.Remove(person);

            Console.WriteLine($"Persona eliminada: {person.DNI} - {person.FirstName} {person.LastName}");

            return Ok(new { Message = "Registro eliminado correctamente..." });
        }
    }
}












// using Microsoft.AspNetCore.Mvc;
// using PersonsApp.Entities;

// namespace PersonsApp.Controllers
// {
//     [Route("api/person")]
//     [ApiController]
//     public class PersonController : ControllerBase
//     {
//         private readonly List<PersonEntity> _persons;
//         public PersonController()
//         {

            
//             _persons = new List<PersonEntity>
//             {
//                 new PersonEntity
//                 {
//                     DNI = "0401200012345",
//                     FirstName = "Juan Carlos",
//                     LastName = "Pérez",
//                     Gender = "M",
//                     BirthDate = DateTime.Parse("01/06/2000")
//                 },
//                 new PersonEntity
//                 {
//                     DNI = "0401200012346",
//                     FirstName = "María Michelle",
//                     LastName = "Lopez Pineda",
//                     Gender = "F",
//                     BirthDate = DateTime.Parse("15/03/2000")
//                 },
//                 new PersonEntity
//                 {
//                     DNI = "0401199812347",
//                     FirstName = "Carlos Ismael",
//                     LastName = "Rodriguez Mejía",
//                     Gender = "M",
//                     BirthDate = DateTime.Parse("07/08/1998")
//                 }
//             };
//         }

//         [HttpGet] traer todo
//         public IActionResult GetAll()
//         {
//             return Ok(_persons);
//         }


//         [HttpGet("{dni}")] traer uno
//         public IActionResult GetOne(string dni)
//         {
//             var person = _persons.FirstOrDefault(p => p.DNI == dni);  
//             return person != null ? Ok(person) : NotFound(new {Message = "Persona no encontrada."});
//         }

//         [HttpPost] crear
//         public IActionResult Create(PersonEntity person)
//         {

//             var personExist = _persons.Any(p => p.DNI == person.DNI);

//             if (!personExist)
//             {
//                 _persons.Add(person);
//                 return Created();
//             }

//             return BadRequest(new {Message = "El DNI ya está registrado"});

//         }

//         [HttpPut("{dni}")] editar
//         public IActionResult Update(string dni, PersonEntity person)
//         {
//             var oldPerson = _persons.FirstOrDefault(p => p.DNI == dni);

//             if(oldPerson is null)
//             {
//                 return NotFound(new {Message = "Registro no encontrado"});
//             }

//             _persons.Remove(oldPerson);
//             _persons.Add(person);

//             Console.WriteLine($"Persona Actualizada: {person.DNI} - {person.FirstName} {person.LastName}");

//             return Ok(new {Message = "Registro editado correctamente..."});
//         } 

//         [HttpDelete("{dni}")] borrar
//         public IActionResult Delete(string dni)
//         {
//             var person = _persons.FirstOrDefault(p => p.DNI == dni);

//             if (person is null)
//             {
//                 return NotFound(new { Message = "Registro no encontrado" });
//             }

//             _persons.Remove(person); 

//             Console.WriteLine($"Persona eliminada: {person.DNI} - {person.FirstName} {person.LastName}");

//             return Ok(new { Message = "Registro eliminado correctamente..." });
//         }
//     }
// }





