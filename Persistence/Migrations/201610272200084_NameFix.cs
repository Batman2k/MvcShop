using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class NameFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Specifications", "Product_Id", "dbo.Products");
            DropIndex("dbo.Pictures", new[] { "Product_Id" });
            DropIndex("dbo.Specifications", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Specifications", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.Pictures", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Specifications", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "ProductId");
            CreateIndex("dbo.Specifications", "ProductId");
            AddForeignKey("dbo.Pictures", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Specifications", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specifications", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "ProductId", "dbo.Products");
            DropIndex("dbo.Specifications", new[] { "ProductId" });
            DropIndex("dbo.Pictures", new[] { "ProductId" });
            AlterColumn("dbo.Specifications", "ProductId", c => c.Int());
            AlterColumn("dbo.Pictures", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Specifications", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Pictures", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Specifications", "Product_Id");
            CreateIndex("dbo.Pictures", "Product_Id");
            AddForeignKey("dbo.Specifications", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Pictures", "Product_Id", "dbo.Products", "Id");
        }
    }
}
