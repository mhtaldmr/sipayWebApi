using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class SipayDbContext : IdentityDbContext<User>
{
    public SipayDbContext(DbContextOptions<SipayDbContext> options) : base(options)
    {
    }

    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Invoice> Invoices { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}