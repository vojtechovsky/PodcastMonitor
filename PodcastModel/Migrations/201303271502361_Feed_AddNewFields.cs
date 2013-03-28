namespace PodcastModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feed_AddNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feeds", "Category", c => c.String(maxLength: 300));
            AlterColumn("dbo.Feeds", "Name", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feeds", "Name", c => c.String());
            DropColumn("dbo.Feeds", "Category");
        }
    }
}
