using Room.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Room.Infrastructure.Data;

public class RoomsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Rooms> Rooms { get; set; }
}