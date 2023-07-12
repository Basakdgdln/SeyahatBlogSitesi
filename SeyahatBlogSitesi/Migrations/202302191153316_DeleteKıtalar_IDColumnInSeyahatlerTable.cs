namespace SeyahatBlogSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteKıtalar_IDColumnInSeyahatlerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kullanici = c.String(maxLength: 25, unicode: false),
                        Sifre = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BlogDetays",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100, unicode: false),
                        Giris = c.String(),
                        Resim1 = c.String(),
                        Gelisme = c.String(),
                        Resim2 = c.String(),
                        Sonuc = c.String(),
                        Resim3 = c.String(),
                        Detay = c.String(),
                        Resim4 = c.String(),
                        Detay1 = c.String(),
                        Resim5 = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        UlkeResim = c.String(),
                        RehberID = c.Int(nullable: false),
                        UlkeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Seyahatlers", t => t.UlkeID, cascadeDelete: true)
                .ForeignKey("dbo.SeyahatRehberis", t => t.RehberID, cascadeDelete: true)
                .Index(t => t.RehberID)
                .Index(t => t.UlkeID);
            
            CreateTable(
                "dbo.Seyahatlers",
                c => new
                    {
                        UlkeID = c.Int(nullable: false, identity: true),
                        UlkeAD = c.String(maxLength: 50, unicode: false),
                        Kıtalar_ID = c.Int(nullable: false),
                        Kıtalar_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.UlkeID)
                .ForeignKey("dbo.Kıtalar", t => t.Kıtalar_ID1)
                .Index(t => t.Kıtalar_ID1);
            
            CreateTable(
                "dbo.Kıtalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KıtaAd = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SeyahatRehberis",
                c => new
                    {
                        RehberID = c.Int(nullable: false, identity: true),
                        Rehber = c.String(maxLength: 30, unicode: false),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.RehberID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        Giris = c.String(),
                        Gelisme = c.String(),
                        Sonuc = c.String(),
                        BlogImage = c.String(),
                        BlogTür = c.String(),
                        BegeniDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yorumlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(maxLength: 25, unicode: false),
                        Mail = c.String(maxLength: 25, unicode: false),
                        Yorum = c.String(maxLength: 8000, unicode: false),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Ekips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Görev = c.String(),
                        FotoUrl = c.String(),
                        Hakkında = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hakkımızda",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FotoUrl = c.String(maxLength: 100, unicode: false),
                        Hakkimizda = c.String(),
                        Facebook = c.String(),
                        İnstagram = c.String(),
                        Twitter = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.İletisim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(maxLength: 25, unicode: false),
                        Mail = c.String(maxLength: 25, unicode: false),
                        Konu = c.String(maxLength: 15, unicode: false),
                        Mesaj = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlars", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.BlogDetays", "RehberID", "dbo.SeyahatRehberis");
            DropForeignKey("dbo.Seyahatlers", "Kıtalar_ID1", "dbo.Kıtalar");
            DropForeignKey("dbo.BlogDetays", "UlkeID", "dbo.Seyahatlers");
            DropIndex("dbo.Yorumlars", new[] { "BlogID" });
            DropIndex("dbo.Seyahatlers", new[] { "Kıtalar_ID1" });
            DropIndex("dbo.BlogDetays", new[] { "UlkeID" });
            DropIndex("dbo.BlogDetays", new[] { "RehberID" });
            DropTable("dbo.İletisim");
            DropTable("dbo.Hakkımızda");
            DropTable("dbo.Ekips");
            DropTable("dbo.Yorumlars");
            DropTable("dbo.Blogs");
            DropTable("dbo.SeyahatRehberis");
            DropTable("dbo.Kıtalar");
            DropTable("dbo.Seyahatlers");
            DropTable("dbo.BlogDetays");
            DropTable("dbo.Admins");
        }
    }
}
