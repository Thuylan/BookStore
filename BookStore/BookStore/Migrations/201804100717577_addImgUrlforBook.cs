namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgUrlforBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImgUrl");
        }
    }
}
