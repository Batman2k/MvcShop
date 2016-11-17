using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class NullableLimitedOffer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "LimitedOffer", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "LimitedOffer", c => c.DateTime(nullable: false));
        }
    }
}
