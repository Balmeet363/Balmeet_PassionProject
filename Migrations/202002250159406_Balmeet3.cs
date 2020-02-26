namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.poetries", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.poetries", new[] { "Artist_ArtistID" });
            CreateTable(
                "dbo.poetryArtists",
                c => new
                    {
                        poetry_poetryID = c.Int(nullable: false),
                        Artist_ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.poetry_poetryID, t.Artist_ArtistID })
                .ForeignKey("dbo.poetries", t => t.poetry_poetryID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .Index(t => t.poetry_poetryID)
                .Index(t => t.Artist_ArtistID);
            
            DropColumn("dbo.poetries", "Artist_ArtistID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.poetries", "Artist_ArtistID", c => c.Int());
            DropForeignKey("dbo.poetryArtists", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.poetryArtists", "poetry_poetryID", "dbo.poetries");
            DropIndex("dbo.poetryArtists", new[] { "Artist_ArtistID" });
            DropIndex("dbo.poetryArtists", new[] { "poetry_poetryID" });
            DropTable("dbo.poetryArtists");
            CreateIndex("dbo.poetries", "Artist_ArtistID");
            AddForeignKey("dbo.poetries", "Artist_ArtistID", "dbo.Artists", "ArtistID");
        }
    }
}
