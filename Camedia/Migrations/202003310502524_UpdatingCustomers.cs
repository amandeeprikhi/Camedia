namespace Camedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}
