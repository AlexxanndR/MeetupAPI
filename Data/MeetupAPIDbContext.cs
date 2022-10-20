using MeetupAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Data
{
    public class MeetupAPIDbContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; }

        public MeetupAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
