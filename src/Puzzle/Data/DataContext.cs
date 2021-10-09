using Microsoft.EntityFrameworkCore;
using Puzzle.Models;

namespace Puzzle.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<ExampleModel> ExampleModels { get; set; }
    }
}