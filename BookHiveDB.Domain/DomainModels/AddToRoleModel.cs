using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain.DomainModels
{
    public class AddToRoleModel
    {
        public string Username { get; set; }
        public List<string> usernames { get; set; }
        public List<string> roles { get; set; }
        public string SelectedRole { get; set; }
    }
}
