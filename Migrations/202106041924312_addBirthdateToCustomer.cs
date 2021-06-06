namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}