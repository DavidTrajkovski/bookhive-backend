﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DTO.REST
{
    public class Author : BaseEntity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string biography { get; set; }
    }
}