
using BookHiveDB.Domain.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DTO.REST;

public class OrderDTO : BaseEntity
{
    public string UserId { get; set; }
    public BookHiveApplicationUserDTO User { get; set; }
}