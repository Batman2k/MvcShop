using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class AddedStringLenghtToProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "SubCategory", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "SubCategory", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "SubCategory", c => c.String());
            AlterColumn("dbo.Products", "SubCategory", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
