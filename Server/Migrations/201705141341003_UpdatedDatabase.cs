namespace Server
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(unicode: false),
                        ChairID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chairs", t => t.ChairID, cascadeDelete: true)
                .Index(t => t.ChairID);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DisciplineTeachers",
                c => new
                    {
                        Discipline_ID = c.Int(nullable: false),
                        Teacher_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_ID, t.Teacher_ID })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_ID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .Index(t => t.Discipline_ID)
                .Index(t => t.Teacher_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisciplineTeachers", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.DisciplineTeachers", "Discipline_ID", "dbo.Disciplines");
            DropForeignKey("dbo.Teachers", "ChairID", "dbo.Chairs");
            DropForeignKey("dbo.Chairs", "FacultyID", "dbo.Faculties");
            DropIndex("dbo.DisciplineTeachers", new[] { "Teacher_ID" });
            DropIndex("dbo.DisciplineTeachers", new[] { "Discipline_ID" });
            DropIndex("dbo.Teachers", new[] { "ChairID" });
            DropIndex("dbo.Chairs", new[] { "FacultyID" });
            DropTable("dbo.DisciplineTeachers");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Teachers");
            DropTable("dbo.Faculties");
            DropTable("dbo.Chairs");
        }
    }
}
