namespace ReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewersController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        ReviewerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                        ReviewerImage = c.String(),
                        ReviewerBio = c.String(),
                    })
                .PrimaryKey(t => t.ReviewerID);
            
            AddColumn("dbo.Reviews", "Reviewer_ReviewerID", c => c.Int());
            CreateIndex("dbo.Reviews", "Reviewer_ReviewerID");
            AddForeignKey("dbo.Reviews", "Reviewer_ReviewerID", "dbo.Reviewers", "ReviewerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Reviewer_ReviewerID", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "Reviewer_ReviewerID" });
            DropColumn("dbo.Reviews", "Reviewer_ReviewerID");
            DropTable("dbo.Reviewers");
        }
    }
}
