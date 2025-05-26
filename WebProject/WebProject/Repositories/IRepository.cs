namespace WebProject.Repositories;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}
