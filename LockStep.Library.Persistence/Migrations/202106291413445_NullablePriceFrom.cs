namespace LockStep.Library.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullablePriceFrom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "To", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "To", c => c.DateTime(nullable: false));
        }
    }
}
