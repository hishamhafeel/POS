using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pos.Configuration;
using Pos.Web;

namespace Pos.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PosDbContextFactory : IDesignTimeDbContextFactory<PosDbContext>
    {
        public PosDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PosDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PosDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PosConsts.ConnectionStringName));

            return new PosDbContext(builder.Options);
        }
    }
}
