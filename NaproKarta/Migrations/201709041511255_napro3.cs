namespace NaproKarta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class napro3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cycles", "RowNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Observations", "ColNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Observations", "ColNumber");
            DropColumn("dbo.Cycles", "RowNumber");
        }
    }
}
