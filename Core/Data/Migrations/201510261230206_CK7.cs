namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "CountryCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "CountryCode");
        }
    }
}
