namespace PodcastModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feed_AddUri : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feeds", "Uri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feeds", "Uri");
        }
    }
}
