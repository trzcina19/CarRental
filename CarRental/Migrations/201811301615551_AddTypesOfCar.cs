namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypesOfCar : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO TypeOfCars (Id, Name) VALUES (1, 'Hatchback')");
            Sql("INSERT INTO TypeOfCars (Id, Name) VALUES (2, 'Limousine')");
            Sql("INSERT INTO TypeOfCars (Id, Name) VALUES (3, 'Sports car')");
        }
        
        public override void Down()
        {
        }
    }
}
