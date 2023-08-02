using Application.Interfaces.UnitOfWork;
using Infrastructure.DbContext;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SipayDbContext _dbContext;

    public UnitOfWork(SipayDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}