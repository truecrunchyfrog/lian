using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Entities;

namespace Backend;

public class BackendContext : DbContext
{
  public required DbSet<Organization> Organizations { get; set; }
  public required DbSet<InternshipPosition> InternshipPositions { get; set; }
  public required DbSet<Tag> Tags { get; set; }

  public BackendContext(DbContextOptions<BackendContext> options) : base(options) {}
}
