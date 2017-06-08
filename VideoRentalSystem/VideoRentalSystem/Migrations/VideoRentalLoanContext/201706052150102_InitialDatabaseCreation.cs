//<auto-generated />
namespace VideoRentalSystem.Migrations.VideoRentalLoanContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Tarif_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Tarifs", t => t.Tarif_Id)
                .Index(t => t.Tarif_Id);
            
            CreateTable(
                "public.Tarifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        MaxNumberOfDays = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Loans", "Tarif_Id", "public.Tarifs");
            DropIndex("public.Loans", new[] { "Tarif_Id" });
            DropTable("public.Tarifs");
            DropTable("public.Loans");
        }
    }
}
