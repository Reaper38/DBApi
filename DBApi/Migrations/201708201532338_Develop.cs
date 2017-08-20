namespace DBApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Develop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Catalog_Id = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CatalogModels", t => t.Catalog_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Catalog_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskModels", "Catalog_Id", "dbo.CatalogModels");
            DropIndex("dbo.TaskModels", new[] { "User_Id" });
            DropIndex("dbo.TaskModels", new[] { "Catalog_Id" });
            DropTable("dbo.TaskModels");
            DropTable("dbo.CatalogModels");
        }
    }
}
