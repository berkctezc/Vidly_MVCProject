namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedIsSubscribedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}