namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DOB = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artists");
        }
    }
}
