

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DTO.REST;

public class GenreDTO : BaseEntity
{
    public string GenreName { get; set; }

}