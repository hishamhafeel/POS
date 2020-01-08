using System.Threading.Tasks;
using Pos.Configuration.Dto;

namespace Pos.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
