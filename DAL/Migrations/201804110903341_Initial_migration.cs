namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        WorkingTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreProduct",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.ProductId })
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreProduct", "ProductId", "dbo.Products");
            DropForeignKey("dbo.StoreProduct", "StoreId", "dbo.Stores");
            DropIndex("dbo.StoreProduct", new[] { "ProductId" });
            DropIndex("dbo.StoreProduct", new[] { "StoreId" });
            DropTable("dbo.StoreProduct");
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
        }
    }
}
