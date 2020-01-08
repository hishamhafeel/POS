﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Pos.Sessions.Dto;

namespace Pos.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
