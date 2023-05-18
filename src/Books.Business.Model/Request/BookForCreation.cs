using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Books.Business.Model.Request
{
    public class BookForCreation
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Title { get; set; } 

        public string Description { get; set; }

        public IFormFile FormFile { get; set; }
    }

}
