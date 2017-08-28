using SourceControlSystem.Data;
using SourceControlSystem.Data.Migrations;
using System.Data.Entity;

namespace SourceControlSystem.Api
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SourceControlSystemDbContext, Configuration>());
            SourceControlSystemDbContext.Create().Database.Initialize(true);
        }
    }
}