using Microsoft.EntityFrameworkCore;
using Osa_Lab_Doker.Data.Entities;

namespace Osa_Lab_Doker.Data;

public class BackendDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
