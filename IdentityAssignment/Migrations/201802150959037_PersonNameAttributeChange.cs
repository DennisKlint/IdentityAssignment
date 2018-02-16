namespace IdentityAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonNameAttributeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonModels", "Name", c => c.Int(nullable: false));
        }
    }
}
