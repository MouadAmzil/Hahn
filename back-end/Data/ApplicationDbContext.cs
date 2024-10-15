using Hahn_Task.Contract;
using Hahn_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some initial tickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Description = "Initial Ticket 1 By Amzil", Status = TicketStatus.Closed, Date = DateTime.Now.AddDays(-10) },
                new Ticket { TicketId = 2, Description = "Initial Ticket 2 By Hahn", Status = TicketStatus.Open, Date = DateTime.Now.AddDays(-5) },
                new Ticket { TicketId = 3, Description = "Initial Ticket 3 By Seidel", Status = TicketStatus.Closed, Date = DateTime.Now }
            );
        }
    }
}
