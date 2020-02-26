namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentID = c.Int(nullable: false, identity: true),
                        commentDesc = c.String(),
                        poetryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.commentID)
                .ForeignKey("dbo.Comments", t => t.poetryID)
                .ForeignKey("dbo.poetries", t => t.poetryID, cascadeDelete: true)
                .Index(t => t.poetryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "poetryID", "dbo.poetries");
            DropForeignKey("dbo.Comments", "poetryID", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "poetryID" });
            DropTable("dbo.Comments");
        }
    }
}
