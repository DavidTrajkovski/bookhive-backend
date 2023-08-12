using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHiveDB.Domain.Dtos.Rest
{
    public class UpdateUserDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
