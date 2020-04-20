namespace InterviewFeedback_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultData : DbMigration
    {
        public override void Up()
        {
            SqlFile("..\\..\\SqlScripts\\CreateDefaultData.sql");
        }
        
        public override void Down()
        {
            SqlFile("..\\..\\SqlScripts\\RemoveDefaultData.sql");
        }
    }
}
