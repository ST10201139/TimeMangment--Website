using Final_POE_TimeMangement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_POE_TimeMangement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Modules> Module { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<StudyHours> StudyHour { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}