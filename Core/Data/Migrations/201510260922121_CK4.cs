namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "line_2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Addresses", "line_3", c => c.String(maxLength: 100));
            AlterColumn("dbo.Addresses", "primary_phone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Addresses", "primary_email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "primary_email", c => c.String());
            AlterColumn("dbo.Addresses", "primary_phone", c => c.String());
            AlterColumn("dbo.Addresses", "line_3", c => c.String());
            AlterColumn("dbo.Addresses", "line_2", c => c.String());
        }
    }
}
