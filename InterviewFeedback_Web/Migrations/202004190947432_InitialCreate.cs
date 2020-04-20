namespace InterviewFeedback_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        TotalApplicants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionNumber = c.Int(nullable: false),
                        QuestionAnswer = c.String(),
                        QuestionFeedbackTotal = c.Int(nullable: false),
                        QuestionDisplay = c.String(),
                        Feedback_FeedbackId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_FeedbackId)
                .Index(t => t.Feedback_FeedbackId);
            
            CreateTable(
                "dbo.QuestionConfigurations",
                c => new
                    {
                        QuestionConfigurationId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        QuestionNumber = c.Int(nullable: false),
                        QuestionAlpahRange = c.String(),
                        QuestionTypeDescription = c.String(),
                        Feedback_FeedbackId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionConfigurationId)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_FeedbackId)
                .Index(t => t.Feedback_FeedbackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionConfigurations", "Feedback_FeedbackId", "dbo.Feedbacks");
            DropForeignKey("dbo.Questions", "Feedback_FeedbackId", "dbo.Feedbacks");
            DropIndex("dbo.QuestionConfigurations", new[] { "Feedback_FeedbackId" });
            DropIndex("dbo.Questions", new[] { "Feedback_FeedbackId" });
            DropTable("dbo.QuestionConfigurations");
            DropTable("dbo.Questions");
            DropTable("dbo.Feedbacks");
        }
    }
}
