namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FacultyID = c.Int(),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ChairID = c.Int(),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chairs", t => t.ChairID)
                .Index(t => t.ChairID);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherDisciplines",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        Discipline_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Discipline_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Discipline_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherDisciplines", "Discipline_ID", "dbo.Disciplines");
            DropForeignKey("dbo.TeacherDisciplines", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "ChairID", "dbo.Chairs");
            DropForeignKey("dbo.Chairs", "FacultyID", "dbo.Faculties");
            DropIndex("dbo.TeacherDisciplines", new[] { "Discipline_ID" });
            DropIndex("dbo.TeacherDisciplines", new[] { "Teacher_ID" });
            DropIndex("dbo.Teachers", new[] { "ChairID" });
            DropIndex("dbo.Chairs", new[] { "FacultyID" });
            DropTable("dbo.TeacherDisciplines");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Teachers");
            DropTable("dbo.Faculties");
            DropTable("dbo.Chairs");
        }
    }
}
