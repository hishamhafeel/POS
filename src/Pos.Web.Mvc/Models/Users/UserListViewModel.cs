using System.Collections.Generic;
using Pos.Roles.Dto;
using Pos.Users.Dto;

namespace Pos.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
