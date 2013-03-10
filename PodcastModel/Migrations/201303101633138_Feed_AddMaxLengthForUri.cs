namespace PodcastModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feed_AddMaxLengthForUri : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feeds", "Uri", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feeds", "Uri", c => c.String());
        }
    }
}
