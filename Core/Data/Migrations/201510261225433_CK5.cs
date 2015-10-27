namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Addresses", name: "country_code", newName: "CountryCode");
            AlterColumn("dbo.Addresses", "CountryCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "CountryCode", c => c.String(nullable: false, maxLength: 10));
            RenameColumn(table: "dbo.Addresses", name: "CountryCode", newName: "country_code");
        }
    }
}
