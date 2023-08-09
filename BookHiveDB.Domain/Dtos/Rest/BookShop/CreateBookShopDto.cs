namespace BookHiveDB.Domain.Dtos.Rest.BookShop;

public class CreateBookShopDto
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string WebsiteLink { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
