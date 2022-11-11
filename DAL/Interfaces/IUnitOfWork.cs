using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IPositionRepository PositionRepository {get;}
    }
}
