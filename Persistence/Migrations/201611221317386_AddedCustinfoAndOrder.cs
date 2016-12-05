namespace RapidMountain.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustinfoAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        AddressOne = c.String(maxLength: 150),
                        AddressTwo = c.String(maxLength: 150),
                        City = c.String(maxLength: 100),
                        Province = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 20),
                        PhoneNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        IsJustBilling = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressOne = c.String(),
                        AddressTwo = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        DatePlaced = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                        PaymentMethod = c.String(),
                        TrackingNumber = c.String(),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderAddresses", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.CustomerInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.OrderAddresses", new[] { "OrderId" });
            DropIndex("dbo.CustomerInfoes", new[] { "UserId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.OrderAddresses");
            DropTable("dbo.CustomerInfoes");
        }
    }
}
