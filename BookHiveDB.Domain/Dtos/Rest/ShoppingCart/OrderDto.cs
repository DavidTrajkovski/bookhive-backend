using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Domain.Dtos.Rest.ShoppingCart;

public class OrderDto : BaseEntity
{
    public string UserId { get; set; }
    public BookHiveApplicationUser User { get; set; }
}