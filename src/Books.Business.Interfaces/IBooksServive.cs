using Books.Business.Model;
using Books.Business.Model.Request;
using Books.Core.Helpers;
using Microsoft.AspNetCore.JsonPatch;

namespace Books.Business.Interfaces
{
    public interface IBooksServive
    {
        Task<PagedList<Book>> GetBooksAsync(QueryParams searchParams);

        Task<Book> GetBookAsync(Guid id);

        Task<Guid> AddBook(BookForCreation bookToAdd);

        Task UpdateBookPatchAsync(Guid bookId, JsonPatchDocument<Book> model);
    }
}
