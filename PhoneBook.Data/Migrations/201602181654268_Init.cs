namespace PhoneBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(maxLength: 450),
                        ContactTypeId = c.Int(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.EmailAddress)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                        Surname = c.String(maxLength: 450),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name)
                .Index(t => t.Surname);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(maxLength: 450),
                        ContactTypeId = c.Int(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PhoneNumber)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.Phones", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.Phones", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Emails", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            DropIndex("dbo.Phones", new[] { "ContactTypeId" });
            DropIndex("dbo.Phones", new[] { "PhoneNumber" });
            DropIndex("dbo.Persons", new[] { "Surname" });
            DropIndex("dbo.Persons", new[] { "Name" });
            DropIndex("dbo.Emails", new[] { "PersonId" });
            DropIndex("dbo.Emails", new[] { "ContactTypeId" });
            DropIndex("dbo.Emails", new[] { "EmailAddress" });
            DropTable("dbo.Phones");
            DropTable("dbo.Persons");
            DropTable("dbo.Emails");
            DropTable("dbo.ContactTypes");
        }
    }
}
