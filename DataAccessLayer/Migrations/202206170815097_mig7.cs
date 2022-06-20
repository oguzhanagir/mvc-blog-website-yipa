namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        TitleHome = c.String(maxLength: 50),
                        ContentHome = c.String(maxLength: 500),
                        ImagePathHome = c.String(maxLength: 100),
                        TitleAbout = c.String(maxLength: 50),
                        ContentAbout = c.String(maxLength: 500),
                        ImagePathAbout = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Password = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Surname = c.String(maxLength: 30),
                        ImagePath = c.String(maxLength: 30),
                        About = c.String(maxLength: 800),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        ImagePath = c.String(maxLength: 30),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(maxLength: 1500),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        Mail = c.String(maxLength: 30),
                        Text = c.String(maxLength: 500),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        SurName = c.String(maxLength: 30),
                        Mail = c.String(maxLength: 30),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "AuthorID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
