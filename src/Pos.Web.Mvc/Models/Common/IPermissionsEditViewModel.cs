using System.Collections.Generic;
using Pos.Roles.Dto;

namespace Pos.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}