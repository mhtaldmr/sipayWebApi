namespace Application.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChanges();
}