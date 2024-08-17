using AutoMapper;
using Microservices.Services.Schools.Models;
using Microservices.Services.Schools.Models.Dtos;

namespace Microservices.Services.Schools.Repositories;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<PersonDto, Person>();
            config.CreateMap<Person, PersonDto>();
        });

        return mappingConfig;
    }
}
