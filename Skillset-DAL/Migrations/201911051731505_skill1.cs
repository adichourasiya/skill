namespace Skillset_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skill1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EmployeeCode = c.String(),
                        Name = c.String(),
                        DateOfJoining = c.DateTime(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        QualificationId = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        MobileNumber = c.Double(nullable: false),
                        Gender = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DesignationId)
                .Index(t => t.RoleId)
                .Index(t => t.QualificationId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                        RatingDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        IsSpecialSkill = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Employees", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "QualificationId" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Skills");
            DropTable("dbo.SkillRatings");
            DropTable("dbo.Ratings");
            DropTable("dbo.Roles");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
