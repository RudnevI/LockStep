namespace LockStep.Library.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Description = c.String(),
                        Book_Id = c.Int(),
                        BookVote_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.BookVotes", t => t.BookVote_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.BookVote_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookComments", "BookVote_Id", "dbo.BookVotes");
            DropForeignKey("dbo.BookComments", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookComments", new[] { "BookVote_Id" });
            DropIndex("dbo.BookComments", new[] { "Book_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.BookComments");
        }
    }
}
