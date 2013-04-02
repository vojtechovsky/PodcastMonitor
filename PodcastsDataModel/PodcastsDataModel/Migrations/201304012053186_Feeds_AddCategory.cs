using System.Data.Entity.Migrations;

namespace PodcastMonitor.DataModel.Migrations
{
    public partial class Feeds_AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Feeds", "Category_Id", c => c.Int());
            AddForeignKey("dbo.Feeds", "Category_Id", "dbo.Categories", "Id");
            CreateIndex("dbo.Feeds", "Category_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Feeds", new[] { "Category_Id" });
            DropForeignKey("dbo.Feeds", "Category_Id", "dbo.Categories");
            DropColumn("dbo.Feeds", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
