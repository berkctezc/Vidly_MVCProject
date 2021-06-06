namespace Vidly_MVCProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into genres (name) values ('Sci-fi')");
            Sql("Insert into genres (name) values ('Comedy')");
            Sql("Insert into genres (name) values ('Drama')");
            Sql("Insert into genres (name) values ('Action')");
            Sql("Insert into genres (name) values ('Adventure')");
            Sql("Insert into genres (name) values ('Western')");
            Sql("Insert into genres (name) values ('Fantasy')");
            Sql("Insert into genres (name) values ('Animation')");
            Sql("Insert into genres (name) values ('Horror')");
            Sql("Insert into genres (name) values ('Thriller')");
        }

        public override void Down()
        {
        }
    }
}