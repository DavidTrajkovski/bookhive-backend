using System.Collections.Generic;

namespace BookHiveDB.Domain.Models;

public class AddToRoleModel
{
    public string Username { get; set; }
    public List<string> Usernames { get; set; }
    public List<string> Roles { get; set; }
    public string SelectedRole { get; set; }
}
