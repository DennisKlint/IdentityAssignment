namespace IdentityAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonCityID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonModels", "CountryModelsID", "dbo.CountryModels");
            DropForeignKey("dbo.PersonModels", "CityModels_ID", "dbo.CityModels");
            DropIndex("dbo.PersonModels", new[] { "CountryModelsID" });
            DropIndex("dbo.PersonModels", new[] { "CityModels_ID" });
            RenameColumn(table: "dbo.PersonModels", name: "CityModels_ID", newName: "CityModelsID");
            AlterColumn("dbo.PersonModels", "CityModelsID", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonModels", "CityModelsID");
            AddForeignKey("dbo.PersonModels", "CityModelsID", "dbo.CityModels", "ID", cascadeDelete: true);
            DropColumn("dbo.PersonModels", "CountryModelsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonModels", "CountryModelsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PersonModels", "CityModelsID", "dbo.CityModels");
            DropIndex("dbo.PersonModels", new[] { "CityModelsID" });
            AlterColumn("dbo.PersonModels", "CityModelsID", c => c.Int());
            RenameColumn(table: "dbo.PersonModels", name: "CityModelsID", newName: "CityModels_ID");
            CreateIndex("dbo.PersonModels", "CityModels_ID");
            CreateIndex("dbo.PersonModels", "CountryModelsID");
            AddForeignKey("dbo.PersonModels", "CityModels_ID", "dbo.CityModels", "ID");
            AddForeignKey("dbo.PersonModels", "CountryModelsID", "dbo.CountryModels", "ID", cascadeDelete: true);
        }
    }
}
