namespace MunicipalityServiceApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventsAndAnnouncements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Message = c.String(nullable: false),
                        Category = c.String(nullable: false, maxLength: 50),
                        Priority = c.String(maxLength: 20),
                        DatePublished = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Location = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        Category = c.String(nullable: false, maxLength: 100),
                        Priority = c.String(maxLength: 20),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Announcements");
        }
    }
}
