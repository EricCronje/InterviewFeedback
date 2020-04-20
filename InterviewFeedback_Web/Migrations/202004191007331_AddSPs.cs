namespace InterviewFeedback_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSPs : DbMigration
    {
        public override void Up()
        {
            SqlFile("..\\..\\SQLScripts\\SpCreate.sql");
        }
        
        public override void Down()
        {
            SqlFile("..\\..\\SQLScripts\\SpDrop.sql");
        }
    }
}
