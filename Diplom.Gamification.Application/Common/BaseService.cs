using AutoMapper;
using Diplom.Gamification.Application.Interfaces;

namespace Diplom.Gamification.Application.Common
{
    public abstract class BaseService
    {
        private protected readonly IUnitOfWork _unitOfWork;
        private protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
