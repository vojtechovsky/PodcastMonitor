// <auto-generated />
namespace PodcastModel.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class Feed_AddMaxLengthForUri : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Feed_AddMaxLengthForUri));
        
        string IMigrationMetadata.Id
        {
            get { return "201303101633138_Feed_AddMaxLengthForUri"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}