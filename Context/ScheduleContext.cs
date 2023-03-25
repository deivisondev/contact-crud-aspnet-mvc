using ContactCrudAspNetMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactCrudAspNetMvc.Context
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
