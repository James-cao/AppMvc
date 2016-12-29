using Hugo.Mvc.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace Hugo.Mvc.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MvcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcContext context)
        {
            
        }
    }
}
