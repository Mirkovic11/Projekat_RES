namespace Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDs1Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ds1Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumUpisa = c.String(),
                        VrijednostDigital = c.Int(nullable: false),
                        VrijednostAnalog = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ds2Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumUpisa = c.String(),
                        VrijednostCustom = c.Int(nullable: false),
                        VrijednostLimitSet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ds3Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumUpisa = c.String(),
                        VrijednostSingleNode = c.Int(nullable: false),
                        VrijednostMultipleNode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ds4Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumUpisa = c.String(),
                        VrijednostConsumer = c.Int(nullable: false),
                        VrijednostSource = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ds4Model");
            DropTable("dbo.Ds3Model");
            DropTable("dbo.Ds2Model");
            DropTable("dbo.Ds1Model");
        }
    }
}
