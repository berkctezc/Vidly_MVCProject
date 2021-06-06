namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateNameValuesMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set name='Pay as you go' where id=1");
            Sql("Update MembershipTypes set name='Monthly' where id=2");
            Sql("Update MembershipTypes set name='Quarterly' where id=3");
            Sql("Update MembershipTypes set name='Annually' where id=4");
        }

        public override void Down()
        {
        }
    }
}