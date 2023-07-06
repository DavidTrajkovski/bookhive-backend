using BookHiveDB.Domain.Identity;
using System;

namespace BookHiveDB.Domain.DomainModels
{
    public class UserBook : BaseEntity
    {
        public string UserId { get; set; }
        public BookHiveApplicationUser BookHiveApplicationUser { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int lastPageRead { get; set; }

        public double getPercentageRead(int totalPages)
        {
            if (lastPageRead == 0)
                return 0;
            else
                return Math.Round((((double)lastPageRead / (double)totalPages) * 100), 2);
        }

    }
}
