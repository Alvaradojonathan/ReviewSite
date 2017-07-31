namespace ReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ReviewerID", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "ReviewerID" });
            RenameColumn(table: "dbo.Reviews", name: "ReviewerID", newName: "Reviewer_ReviewerID");
            AlterColumn("dbo.Reviews", "Reviewer_ReviewerID", c => c.Int());
            CreateIndex("dbo.Reviews", "Reviewer_ReviewerID");
            AddForeignKey("dbo.Reviews", "Reviewer_ReviewerID", "dbo.Reviewers", "ReviewerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Reviewer_ReviewerID", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "Reviewer_ReviewerID" });
            AlterColumn("dbo.Reviews", "Reviewer_ReviewerID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reviews", name: "Reviewer_ReviewerID", newName: "ReviewerID");
            CreateIndex("dbo.Reviews", "ReviewerID");
            AddForeignKey("dbo.Reviews", "ReviewerID", "dbo.Reviewers", "ReviewerID", cascadeDelete: true);
        }
    }
}
