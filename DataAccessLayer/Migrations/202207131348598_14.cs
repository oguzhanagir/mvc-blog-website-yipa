namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sents",
                c => new
                    {
                        SentID = c.Int(nullable: false, identity: true),
                        ToMail = c.String(maxLength: 40),
                        Subject = c.String(maxLength: 120),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.SentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sents");
        }
    }
}
