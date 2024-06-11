using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace webapp.Person
{
public class Person
{
    public int Id { get; set; }
    public  string FirstName { get; set; }
    public string LastName { get; set; }
}

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Person> Person { get; set; }
}
}