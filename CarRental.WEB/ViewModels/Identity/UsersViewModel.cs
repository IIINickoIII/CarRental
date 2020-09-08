using CarRental.BLL.Dto;
using System.Collections.Generic;

namespace CarRental.WEB.ViewModels.Identity
{
    public class UsersViewModel
    {
        public IEnumerable<UserDto> UserDtos { get; set; }
        public IEnumerable<RoleDto> RoleDtos { get; set; }
    }
}