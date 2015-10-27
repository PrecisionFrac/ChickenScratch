namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "customer_status", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Addresses", "line_1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Addresses", "town_city", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Addresses", "state_province", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Addresses", "country_code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customers", "customer_to_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "customer_to_date", c => c.DateTime());
            AlterColumn("dbo.Addresses", "country_code", c => c.String());
            AlterColumn("dbo.Addresses", "state_province", c => c.String());
            AlterColumn("dbo.Addresses", "town_city", c => c.String());
            AlterColumn("dbo.Addresses", "line_1", c => c.String());
            DropColumn("dbo.Customers", "customer_status");
        }
    }
}
