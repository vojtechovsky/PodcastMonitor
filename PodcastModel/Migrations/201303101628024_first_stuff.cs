namespace PodcastModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_stuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feeds");
        }
    }
}
