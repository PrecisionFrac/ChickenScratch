namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "CountryCode", c => c.Int(nullable: false));
        }
    }
}
