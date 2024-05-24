using GaribExam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GaribExam.DAL
{
	public class BlogerContext : IdentityDbContext
	{
        public DbSet<Employee> Employees { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
        public BlogerContext(DbContextOptions options) : base(options)
		{
		}
	}
}
