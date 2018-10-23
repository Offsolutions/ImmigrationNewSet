namespace ImmigrationNewSetup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        name = c.String(),
                        email = c.String(),
                        contact = c.String(),
                        login = c.String(),
                        password = c.String(),
                        Type = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.studentdetails",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        dob = c.DateTime(),
                        gender = c.String(),
                        fathername = c.String(),
                        mothername = c.String(),
                        address = c.String(),
                        phone = c.String(nullable: false),
                        email = c.String(),
                        married = c.String(),
                        board = c.String(),
                        qualification = c.String(),
                        marks = c.String(),
                        gap = c.String(),
                        gapdetail = c.String(),
                        refusal = c.String(),
                        refusaldetail = c.String(),
                        intake = c.String(),
                        note = c.String(),
                        uid = c.String(),
                        username = c.String(),
                        password = c.String(),
                        date = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.studentdetails");
            DropTable("dbo.Accounts");
        }
    }
}
