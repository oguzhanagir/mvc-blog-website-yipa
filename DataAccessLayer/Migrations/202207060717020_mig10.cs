namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Address = c.String(maxLength: 80),
                        IconPath = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.SocialMediaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialMedias");
        }
    }
}
