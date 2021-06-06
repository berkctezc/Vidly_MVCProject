namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}