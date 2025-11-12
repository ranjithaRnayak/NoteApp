using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class NotesAppContextFactory : IDesignTimeDbContextFactory<NotesAppContext>
{
    public NotesAppContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<NotesAppContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        return new NotesAppContext(optionsBuilder.Options);
    }
}