using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.Models;

public class BookShop : BaseEntity
{
    [Display(Name = "Address")]
    public string address { get; set; }
    [Display(Name = "City")]
    public string city { get; set; }
    [Display(Name = "Name")]
    public string name { get; set; }
    [Display(Name = "Email of the bookshop")]
    public string bookshopEmail { get; set; }
    [Display(Name = "Phone Number")]
    public string phoneNumber { get; set; }
    [Display(Name = "Link to the website")]
    public string websiteLink { get; set; }

    public virtual List<Book> Books { get; init; } = new();
    [Display(Name = "Latitude")]
    public double latitude { get; set; }
    [Display(Name = "Longitude")]
    public double longitude { get; set; }
    [Display(Name = "Grade")]
    public double grade { get; set; }
    [Display(Name = "Number of graders")]
    public int numGraders { get; set; }

}
