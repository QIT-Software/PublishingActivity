namespace PublishingActivity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClientDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfessorProfiles", "Email", c => c.String());
            AddColumn("dbo.Publications", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.PublicationStatusTrackers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublicationStatusTrackers", "IsDeleted");
            DropColumn("dbo.Publications", "IsDeleted");
            DropColumn("dbo.ProfessorProfiles", "Email");
        }
    }
}
