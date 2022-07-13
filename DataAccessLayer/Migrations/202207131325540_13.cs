namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SocialMedias", "IconPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialMedias", "IconPath", c => c.String(maxLength: 80));
        }
    }
}
