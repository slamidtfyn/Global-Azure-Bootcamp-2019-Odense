using GacBootcampWebsite.Database;
using System.Collections.Generic;

namespace GacBootcampWebsite.Models
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public UsersViewModel(IEnumerable<User> users)
        {
            Users = users;
        }
    }
}
