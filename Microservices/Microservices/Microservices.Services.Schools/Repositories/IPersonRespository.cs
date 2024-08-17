using Microservices.Services.Schools.Models.Dtos;

namespace Microservices.Services.Schools.Repositories;

public interface IPersonRespository
{
    Task<IEnumerable<PersonDto>> GetAllPersonsAsync();
    Task<PersonDto?> GetPersonByIdAsync(int id);
    Task<PersonDto> CreatePersonByNameAsync(PersonDto person);
    Task<PersonDto> UpdatePersonByNameAsync(PersonDto person);
    Task<bool> DeletePersonByNameAsync(int id);
}
