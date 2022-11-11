using BLL.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BLL.Services
{
    public sealed class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();


        public async Task Add(Position position)
        {
            await _unitOfWork.PositionRepository.Add(position);
        }
    }
}
