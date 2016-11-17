using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class CartSecondKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", new[] { "UserId", "ProductId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "UserId");
        }
    }
}
