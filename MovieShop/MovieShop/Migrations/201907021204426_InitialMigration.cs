namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movie", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movie", "CreatedDate");
        }
    }
}
