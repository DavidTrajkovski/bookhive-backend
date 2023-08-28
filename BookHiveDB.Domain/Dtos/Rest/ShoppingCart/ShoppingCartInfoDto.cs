using System.Collections.Generic;

namespace BookHiveDB.Domain.Dtos.Rest.ShoppingCart;

public class ShoppingCartInfoDto
{
    public List<ShoppingCartBookDto> Books { get; set; }
    public double TotalPrice { get; set; }
}