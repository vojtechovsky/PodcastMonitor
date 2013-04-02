using System.Data.Entity.Migrations;

namespace PodcastMonitor.DataModel.Migrations
{
    public partial class Category_AddLengthToName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
