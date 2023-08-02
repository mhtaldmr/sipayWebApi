using Application.Interfaces.Repositories;
using Domain.Entity;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(SipayDbContext dbContext) : base(dbContext)
    {
    }
}