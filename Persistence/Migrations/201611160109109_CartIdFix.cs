using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class CartIdFix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Carts", "Id");
        }
    }
}
