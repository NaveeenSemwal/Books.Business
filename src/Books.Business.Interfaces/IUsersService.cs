using Books.Business.Model;
using Books.Business.Model.Request;
using Books.Business.Model.Response;
using Books.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace Books.Business.Interfaces
{
    public interface IUsersService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<RegisterationResponsetDto> Register(RegisterationRequestDto registerationRequestDto);

        Task<PagedList<MemberDto>> GetAll(UserParams searchParams);

        Task<MemberDto> Get(string username);

        Task<MemberDto> Get(object id);

        Task<bool> UpdateUser(MemberUpdateDto memberUpdateDto);

        Task<MemberDto> GetUsersWithRoles();

        Task<PhotoDto> AddPhoto(IFormFile file);
    }
}
