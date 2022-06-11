namespace PublishingActivity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PagesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "ProfessorName", c => c.String());
            AddColumn("dbo.Publications", "Pages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publications", "Pages");
            DropColumn("dbo.Publications", "ProfessorName");
        }
    }
}
