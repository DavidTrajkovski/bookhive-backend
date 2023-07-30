using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.Rest.BookShop;

public class BookShopDto : BaseEntity
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string WebsiteLink { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Grade { get; set; }
    public int NumOfGraders { get; set; }
    public List<BookDto> Books { get; set; }
}
