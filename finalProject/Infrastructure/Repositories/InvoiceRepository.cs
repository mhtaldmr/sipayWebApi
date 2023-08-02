using Application.Interfaces.Repositories;
using Domain.Entity;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(SipayDbContext dbContext) : base(dbContext)
    {
    }
}