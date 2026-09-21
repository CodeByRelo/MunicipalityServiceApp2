namespace MunicipalityServiceApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 200),
                        Category = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        AttachmentPath = c.String(maxLength: 500),
                        Status = c.String(nullable: false, maxLength: 50),
                        DateReported = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Issues");
        }
    }
}
