using AutoMapper;
using Microservices.Services.Schools.DbContexts;
using Microservices.Services.Schools.Models;
using Microservices.Services.Schools.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.Schools.Repositories;

public class PersonRepository : IPersonRespository
{
    private readonly ApplicationDbContext _dbContext;
    private IMapper _mapper;

    public PersonRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PersonDto> CreatePersonByNameAsync(PersonDto personDto)
    {
        var person = _mapper.Map<PersonDto, Person>(personDto);
        
        if (person.Id == 0)
        {
            _dbContext.Add(person);
        }
        else
        {
            _dbContext.Update(person);
        }

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Person, PersonDto>(person);
    }

    public async Task<bool> DeletePersonByNameAsync(int id)
    {
        try
        {
            var person = await _dbContext.FindAsync<Person>(id);
            if(person is null)
            {
                return false;
            }

            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
    {
        var persons = await _dbContext.Persons.ToListAsync();

        return _mapper.Map<List<Person>, List<PersonDto>>(persons);
    }

    public async Task<PersonDto?> GetPersonByIdAsync(int id)
    {
        var person = await _dbContext.Persons.FindAsync(id);
        if (person is null)
        {
            return null;
        }

        return _mapper.Map<Person, PersonDto>(person);
    }

    public async Task<PersonDto> UpdatePersonByNameAsync(PersonDto personDto)
    {
        var person = _mapper.Map<PersonDto, Person>(personDto);

        if (person.Id == 0)
        {
            _dbContext.Add(person);
        }
        else
        {
            _dbContext.Update(person);
        }

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Person, PersonDto>(person);
    }
}
