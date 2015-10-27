namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "customer_to_date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "customer_to_date", c => c.DateTime(nullable: false));
        }
    }
}
