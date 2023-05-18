using Books.Core.Helpers;
using Books.Data.Model;

namespace Books.Business.Interfaces
{
    public interface IRolesService
    {
        Task<PagedList<ApplicationRole>> GetRolesAsync(QueryParams searchParams);

        Task<Guid> AddRole(ApplicationRole role);
    }
}
