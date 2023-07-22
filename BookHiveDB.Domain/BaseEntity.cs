using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHiveDB.Domain
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
