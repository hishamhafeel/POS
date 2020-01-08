using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pos.MultiTenancy.Dto;

namespace Pos.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

