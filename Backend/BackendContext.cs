using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Entities;

namespace Backend;

public class BackendContext : DbContext
{
  public required DbSet<Organization> Organizations { get; set; }
  public required DbSet<InternshipPeriod> InternshipPeriods { get; set; }

  public BackendContext(DbContextOptions<BackendContext> options) : base(options) {}
}
