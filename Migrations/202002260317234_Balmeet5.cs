namespace BalmeetPassion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "poetryID", "dbo.Comments");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Comments", "poetryID", "dbo.Comments", "commentID");
        }
    }
}
