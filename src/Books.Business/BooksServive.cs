using AutoMapper;
using Books.Business.Interfaces;
using BusinessModel= Books.Business.Model;
using DataModel = Books.Data.Model;
using Books.Business.Model.Request;
using Books.Core.Helpers;
using Books.Data.Interfaces;
using Microsoft.AspNetCore.JsonPatch;


namespace Books.Business
{
    public class BooksServive : IBooksServive
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksServive(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Primary key which is GUID is auto generated. See migration classes - ValueGeneratedOnAdd()
        /// </summary>
        /// <param name="bookForCreation"></param>
        /// <returns></returns>
        public async Task<Guid> AddBook(BookForCreation bookForCreation)
        {
            var bookEntity = _mapper.Map<DataModel.Book>(bookForCreation);

            _unitOfWork.BooksRepository.AddAsync(bookEntity);
            await _unitOfWork.Complete();

            return bookEntity.Id;
        }

       
        public async Task<BusinessModel.Book> GetBookAsync(Guid id)
        {
            var bookEntity = await _unitOfWork.BooksRepository.GetAsync(x => x.Id == id, traked: false, includeProperties: "Author");

            return _mapper.Map<BusinessModel.Book>(bookEntity);
        }

        public async Task<PagedList<BusinessModel.Book>> GetBooksAsync(QueryParams searchParams)
        {
            var booksEntity = await _unitOfWork.BooksRepository.GetAllAsync(searchParams, includeProperties: "Author");

            return _mapper.Map<PagedList<BusinessModel.Book>>(booksEntity);
        }

        public async Task UpdateBookPatchAsync(Guid bookId, JsonPatchDocument<BusinessModel.Book> model)
        {
            var bookEntity = _mapper.Map<JsonPatchDocument<DataModel.Book>>(model);

            await _unitOfWork.BooksRepository.UpdateBookPatch(bookId, bookEntity);

            await _unitOfWork.Complete();
        }
    }
}
