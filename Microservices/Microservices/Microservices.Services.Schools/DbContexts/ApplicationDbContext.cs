using Microservices.Services.Schools.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.Schools.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Person> Persons { get; set; }
}

