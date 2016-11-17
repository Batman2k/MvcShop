using System.Data.Entity.Migrations;

namespace RapidMountain.Persistence.Migrations
{
    public partial class AddedSpec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Img = c.Binary(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MadeBy = c.String(),
                        Stars = c.Int(nullable: false),
                        Written = c.DateTime(nullable: false),
                        Text = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specifications", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "Product_Id", "dbo.Products");
            DropIndex("dbo.Specifications", new[] { "Product_Id" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Pictures", new[] { "Product_Id" });
            DropTable("dbo.Specifications");
            DropTable("dbo.Reviews");
            DropTable("dbo.Pictures");
        }
    }
}
