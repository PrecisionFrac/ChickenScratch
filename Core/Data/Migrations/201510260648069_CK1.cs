namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "customer_name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "customer_tokensecret", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "customer_tokensecret", c => c.String());
            AlterColumn("dbo.Customers", "customer_name", c => c.String());
        }
    }
}
