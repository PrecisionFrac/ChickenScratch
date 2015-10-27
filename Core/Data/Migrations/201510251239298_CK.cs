namespace ChickenScratch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        address_id = c.Int(nullable: false, identity: true),
                        line_1 = c.String(),
                        line_2 = c.String(),
                        line_3 = c.String(),
                        town_city = c.String(),
                        state_province = c.String(),
                        country_code = c.String(),
                        primary_phone = c.String(),
                        primary_email = c.String(),
                    })
                .PrimaryKey(t => t.address_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(),
                        customer_tokensecret = c.String(),
                        customer_from_date = c.DateTime(nullable: false),
                        customer_to_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.CustomerAddress",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Address_AddressId })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Address_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAddress", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.CustomerAddress", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerAddress", new[] { "Address_AddressId" });
            DropIndex("dbo.CustomerAddress", new[] { "Customer_CustomerId" });
            DropTable("dbo.CustomerAddress");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
