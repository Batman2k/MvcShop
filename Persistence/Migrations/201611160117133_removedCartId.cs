using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class removedCartId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Carts", "UserId");
            DropColumn("dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "UserId", c => c.String());
            AddPrimaryKey("dbo.Carts", "Id");
        }
    }
}
