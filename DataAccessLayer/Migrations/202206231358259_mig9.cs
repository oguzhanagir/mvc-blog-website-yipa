namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        NewsletterId = c.Int(nullable: false, identity: true),
                        Mail = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.NewsletterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Newsletters");
        }
    }
}
