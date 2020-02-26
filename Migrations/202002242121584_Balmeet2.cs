namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.poetries", "Artist_ArtistID", c => c.Int());
            CreateIndex("dbo.poetries", "Artist_ArtistID");
            AddForeignKey("dbo.poetries", "Artist_ArtistID", "dbo.Artists", "ArtistID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.poetries", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.poetries", new[] { "Artist_ArtistID" });
            DropColumn("dbo.poetries", "Artist_ArtistID");
        }
    }
}
