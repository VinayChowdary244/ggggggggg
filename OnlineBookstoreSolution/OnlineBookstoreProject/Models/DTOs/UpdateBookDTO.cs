﻿namespace OnlineBookstoreProject.Models.DTOs
{
    public class UpdateBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public string PublishDate { get; set; }
        public int? Price { get; set; }
    }
}
