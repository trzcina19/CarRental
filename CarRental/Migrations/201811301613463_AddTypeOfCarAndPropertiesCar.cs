namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfCarAndPropertiesCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        TypeOfCarId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfCars", t => t.TypeOfCarId, cascadeDelete: true)
                .Index(t => t.TypeOfCarId);
            
            CreateTable(
                "dbo.TypeOfCars",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "TypeOfCarId", "dbo.TypeOfCars");
            DropIndex("dbo.Cars", new[] { "TypeOfCarId" });
            DropTable("dbo.TypeOfCars");
            DropTable("dbo.Cars");
        }
    }
}
