using Application.Interfaces.Repositories;
using Domain.Entity;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories;

public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(SipayDbContext dbContext) : base(dbContext)
    {
    }
}