using System.Threading.Tasks;
using Abp.Application.Services;
using Pos.Authorization.Accounts.Dto;

namespace Pos.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
