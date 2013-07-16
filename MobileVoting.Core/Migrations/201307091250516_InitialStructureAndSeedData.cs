namespace MobileVoting.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStructureAndSeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionTypes", t => t.TypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeId = c.Int(nullable: false),
                        TypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.VoteOptions",
                c => new
                    {
                        VoteOptionId = c.Int(nullable: false, identity: true),
                        VoteId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteOptionId)
                .ForeignKey("dbo.Votes", t => t.VoteId)
                .ForeignKey("dbo.QuestionOptions", t => t.OptionId)
                .Index(t => t.VoteId)
                .Index(t => t.OptionId);
            
            CreateTable(
                "dbo.VoteOptionWeight",
                c => new
                    {
                        VoteOptionId = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteOptionId)
                .ForeignKey("dbo.VoteOptions", t => t.VoteOptionId)
                .Index(t => t.VoteOptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.VoteOptionWeight", "VoteOptionId", "dbo.VoteOptions");
            DropForeignKey("dbo.VoteOptions", "OptionId", "dbo.QuestionOptions");
            DropForeignKey("dbo.VoteOptions", "VoteId", "dbo.Votes");
            DropForeignKey("dbo.Votes", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TypeId", "dbo.QuestionTypes");
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.VoteOptionWeight", new[] { "VoteOptionId" });
            DropIndex("dbo.VoteOptions", new[] { "OptionId" });
            DropIndex("dbo.VoteOptions", new[] { "VoteId" });
            DropIndex("dbo.Votes", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "TypeId" });
            DropTable("dbo.VoteOptionWeight");
            DropTable("dbo.VoteOptions");
            DropTable("dbo.Votes");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionOptions");
        }
    }
}
