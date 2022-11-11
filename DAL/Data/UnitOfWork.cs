using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        public IPositionRepository PositionRepository => new PositionRepository();

    }
}
