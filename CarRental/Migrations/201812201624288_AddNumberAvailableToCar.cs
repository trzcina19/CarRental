namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NumberAvailable", c => c.Int(nullable: false));
            Sql("Update Cars SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "NumberAvailable");
        }
    }
}
