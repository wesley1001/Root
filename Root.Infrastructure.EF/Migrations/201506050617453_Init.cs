using System.Data.Entity.Migrations;

namespace Root.Infrastructure.EF.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Morpheme",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32),
                        Standard = c.String(),
                        Variant = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32),
                        Stem = c.String(),
                        ExampleSentence = c.String(),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordInterpretation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32),
                        PartOfSpeech = c.Int(nullable: false),
                        Interpretation = c.String(),
                        Order = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Word_Id = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Word", t => t.Word_Id)
                .Index(t => t.Word_Id);
            
            CreateTable(
                "dbo.WordMorpheme",
                c => new
                    {
                        Word_Id = c.String(nullable: false, maxLength: 32),
                        Morpheme_Id = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.Word_Id, t.Morpheme_Id })
                .ForeignKey("dbo.Word", t => t.Word_Id, cascadeDelete: true)
                .ForeignKey("dbo.Morpheme", t => t.Morpheme_Id, cascadeDelete: true)
                .Index(t => t.Word_Id)
                .Index(t => t.Morpheme_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordMorpheme", "Morpheme_Id", "dbo.Morpheme");
            DropForeignKey("dbo.WordMorpheme", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.WordInterpretation", "Word_Id", "dbo.Word");
            DropIndex("dbo.WordMorpheme", new[] { "Morpheme_Id" });
            DropIndex("dbo.WordMorpheme", new[] { "Word_Id" });
            DropIndex("dbo.WordInterpretation", new[] { "Word_Id" });
            DropTable("dbo.WordMorpheme");
            DropTable("dbo.WordInterpretation");
            DropTable("dbo.Word");
            DropTable("dbo.Morpheme");
        }
    }
}
