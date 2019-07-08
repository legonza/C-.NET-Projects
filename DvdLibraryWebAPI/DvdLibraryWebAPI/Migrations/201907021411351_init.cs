namespace DvdLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        dvdId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        releasedYear = c.Int(nullable: false),
                        director = c.String(),
                        rating = c.String(),
                        notes = c.String(),
                    })
                .PrimaryKey(t => t.dvdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
