using AutoMapper;
using Books.Business.Interfaces;
using Books.Core.Helpers;
using Books.Data.Interfaces;
using Books.Data.Model;

namespace Books.Business
{
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public Task<Guid> AddRole(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<ApplicationRole>> GetRolesAsync(QueryParams searchParams)
        {
            var roles = await _unitOfWork.RolesRepository.GetAllAsync(searchParams);

            return _mapper.Map<PagedList<ApplicationRole>>(roles);
        }

    }
}
