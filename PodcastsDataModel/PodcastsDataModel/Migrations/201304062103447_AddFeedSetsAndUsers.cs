namespace PodcastMonitor.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedSetsAndUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 300),
                        FeedUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeedUsers", t => t.FeedUser_Id)
                .Index(t => t.FeedUser_Id);
            
            CreateTable(
                "dbo.FeedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Feeds", "FeedSet_Id", c => c.Int());
            AddForeignKey("dbo.Feeds", "FeedSet_Id", "dbo.FeedSets", "Id");
            CreateIndex("dbo.Feeds", "FeedSet_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeedSets", new[] { "FeedUser_Id" });
            DropIndex("dbo.Feeds", new[] { "FeedSet_Id" });
            DropForeignKey("dbo.FeedSets", "FeedUser_Id", "dbo.FeedUsers");
            DropForeignKey("dbo.Feeds", "FeedSet_Id", "dbo.FeedSets");
            DropColumn("dbo.Feeds", "FeedSet_Id");
            DropTable("dbo.FeedUsers");
            DropTable("dbo.FeedSets");
        }
    }
}
