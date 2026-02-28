using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonsApp.Database;
using PersonsApp.Dtos.Common;
using PersonsApp.Dtos.Persons;
using PersonsApp.Entities;

namespace PersonsApp.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly PersonsDbContext _context;
        public PersonService(PersonsDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseDto<PersonDto>> GetOneById(Guid id)
        {
           var personEntity = await _context.Persons.FirstOrDefaultAsync(p=> p.Id == id );
        if (personEntity is null)
        {
            return new ResponseDto<PersonDto>
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Message ="Registro no encontrado",
                status=false,

            };
           
        }
    
        
        }
    }
}