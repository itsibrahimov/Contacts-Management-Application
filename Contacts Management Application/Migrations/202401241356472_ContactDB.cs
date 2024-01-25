namespace Contacts_Management_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Persons", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "ContactId", c => c.Int(nullable: false));
        }
    }
}
