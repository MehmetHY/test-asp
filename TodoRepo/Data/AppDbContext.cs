using Microsoft.EntityFrameworkCore;
using TodoModels.Models;

namespace TodoRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TodoModel> Todos { get; set; }
    }
}
