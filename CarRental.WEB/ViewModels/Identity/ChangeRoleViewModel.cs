using CarRental.BLL.Dto;
using System.Collections.Generic;

namespace CarRental.WEB.ViewModels.Identity
{
    public class ChangeRoleViewModel
    {
        public UserDto userDto { get; set; }
        public IEnumerable<RoleDto> roleDtos { get; set; }
    }
}