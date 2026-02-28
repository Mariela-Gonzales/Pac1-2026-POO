
using System;
using System.Threading.Tasks;
using PersonsApp.Dtos.Common;
using PersonsApp.Dtos.Persons;

namespace PersonsApp.Services.Persons
{
    public interface IPersonService
    {
        Task<ResponseDto<PersonDto>>GetOneById(Guid id);

    }
}