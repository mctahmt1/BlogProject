﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"), "1395f0da-9eaf-4ba7-9420-b8fe22199eb0", "Superadmin", "SUPERADMIN" },
                    { new Guid("893c5295-04cc-47df-9c95-e6470ac0aece"), "66212e06-1c73-4a97-880d-55120958be9e", "User", "USER" },
                    { new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"), "90f135b7-723b-4296-a86e-5dac64093154", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(1817), null, null, false, null, null, "Asp.NET Core" },
                    { new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(1822), null, null, false, null, null, "VisualStudio 2022" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(2107), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(2113), null, null, "images/visualtest", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 0, "56422c18-ccc9-427e-86ed-630c68dbf209", "superadmin@gmail.com", true, "Ahmet", new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), "Macit", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEP+mYIYXfMEsfJ3t0pZXHMLUvYDUzizV6O/zU5iH3iFZR8GDZ4zcyoXHzEI+m4kTMQ==", "+905537843233", true, "bc7e37a9-b6e7-45b6-a237-7a053feb0fcf", false, "superadmin@gmail.com" },
                    { new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 0, "25c59ab2-12a1-4763-a39f-0e0bc3822e91", "admin@gmail.com", false, "Arzu", new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), "Daban", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBrVMVyQZZuX12S+i+OSd7qmoxeWEeOxq7WIbjSyZgfGCIyzIXYzT4Q4OvUbmKxgtA==", "+905319251468", false, "881f2cde-a21b-46a3-ad9d-60daa35cf41c", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("09c2500a-461b-42c6-9b40-82e4368caa52"), new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(1333), null, null, new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), false, null, null, "Asp.NET Core Deneme Makalesi", new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 15 },
                    { new Guid("0b39d0f5-3f89-428e-af72-4e119bffc287"), new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 5, 19, 4, 37, 39, 586, DateTimeKind.Local).AddTicks(1344), null, null, new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"), new Guid("5ca6b261-e32d-4d26-9719-a98781f37011") },
                    { new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"), new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}