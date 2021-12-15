namespace MKT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CartId, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoBarra = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockActual = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        FotoProducto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.ProductoId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        DireccionId = c.Int(nullable: false),
                        CarritoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CarritoId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UsuarioId, cascadeDelete: false)
                .ForeignKey("dbo.Address", t => t.DireccionId, cascadeDelete: false)
                .Index(t => t.UsuarioId)
                .Index(t => t.DireccionId)
                .Index(t => t.CarritoId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        DireccionCompleta = c.String(),
                        CodigoPostal = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreWeb = c.String(),
                        Bloqueo = c.Int(nullable: false),
                        IntentosLogin = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Apellido = c.String(nullable: false, maxLength: 30),
                        Documento = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        UserToken = c.String(),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: false)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductoId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "DireccionId", "dbo.Address");
            DropForeignKey("dbo.User", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Order", "UsuarioId", "dbo.User");
            DropForeignKey("dbo.Address", "UserId", "dbo.User");
            DropForeignKey("dbo.Cart", "UsuarioId", "dbo.User");
            DropForeignKey("dbo.Order", "CarritoId", "dbo.Cart");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.User", new[] { "RolId" });
            DropIndex("dbo.Address", new[] { "UserId" });
            DropIndex("dbo.Order", new[] { "CarritoId" });
            DropIndex("dbo.Order", new[] { "DireccionId" });
            DropIndex("dbo.Order", new[] { "UsuarioId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductoId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropIndex("dbo.CartItem", new[] { "CartId" });
            DropIndex("dbo.Cart", new[] { "UsuarioId" });
            DropTable("dbo.Rol");
            DropTable("dbo.User");
            DropTable("dbo.Address");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
            DropTable("dbo.Cart");
        }
    }
}
