namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.poetries",
                c => new
                    {
                        poetryID = c.Int(nullable: false, identity: true),
                        poetryName = c.String(),
                        poetryDescription = c.String(),
                        poetryDate = c.String(),
                    })
                .PrimaryKey(t => t.poetryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.poetries");
        }
    }
}
