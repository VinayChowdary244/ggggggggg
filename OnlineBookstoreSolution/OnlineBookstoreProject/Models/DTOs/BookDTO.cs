using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public string PublishDate { get; set; }
        public int? Price { get; set; }
    }
}
