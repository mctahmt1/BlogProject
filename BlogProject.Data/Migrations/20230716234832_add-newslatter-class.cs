using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewslatterclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4b40bb7d-5293-4b7a-94d7-de76e52e6522"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9ed36f69-d2bf-4810-8115-b88d66d11e9f"));

            migrationBuilder.CreateTable(
                name: "NewsLatters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLatters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("f4bfe94d-6c4f-401f-9c08-2cd5a3d1e182"), new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(8893), null, null, new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 15 },
                    { new Guid("fdedbacc-2bb2-4a67-9764-fd2a86cbecfb"), new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(8868), null, null, new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), false, null, null, "Asp.NET Core Deneme Makalesi", new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"),
                column: "ConcurrencyStamp",
                value: "b36c1013-54b5-4851-9509-3a132da95fbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("893c5295-04cc-47df-9c95-e6470ac0aece"),
                column: "ConcurrencyStamp",
                value: "87886b69-a79f-4b12-aa30-3f935a39674b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"),
                column: "ConcurrencyStamp",
                value: "5b8a3e02-ba36-43ba-8c10-6efeed5efa5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0147e6af-8eec-4455-bdab-37d81372c7b8", "AQAAAAEAACcQAAAAENOg4nFhECJBxnhuj5t3pofkMcvungWzg8IWsrNIvwv7dPxS648NWaFA9kAOwTIudA==", "fe8ecfd9-02b5-461c-afa2-64600a913930" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c890c8b-17a9-4931-ac07-391d6c043ce4", "AQAAAAEAACcQAAAAEEKnJRfZNm9Xu1/1HYCFgsl27K3Y+6FA4hnpmp6TbveEEgX2PAHiZrXGvh0qFepoMg==", "4521efbc-4acc-4c47-bf74-771511984978" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 48, 31, 400, DateTimeKind.Local).AddTicks(9409));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsLatters");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f4bfe94d-6c4f-401f-9c08-2cd5a3d1e182"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fdedbacc-2bb2-4a67-9764-fd2a86cbecfb"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("4b40bb7d-5293-4b7a-94d7-de76e52e6522"), new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(2358), null, null, new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), false, null, null, "Asp.NET Core Deneme Makalesi", new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 15 },
                    { new Guid("9ed36f69-d2bf-4810-8115-b88d66d11e9f"), new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(2366), null, null, new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"),
                column: "ConcurrencyStamp",
                value: "4b825dc7-1dc8-4b1a-bc0a-47d931347795");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("893c5295-04cc-47df-9c95-e6470ac0aece"),
                column: "ConcurrencyStamp",
                value: "70278cba-c855-4fc7-bf98-6c55c2977a4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"),
                column: "ConcurrencyStamp",
                value: "dd482ba6-84b6-4cf1-bb58-8159dd3ed4c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90adcb60-6f68-46ab-8864-3ae0673ceaaa", "AQAAAAEAACcQAAAAEGsYK8014FyrVfZOgzcQLpU2PDOVpjHHBk3B8zz5muLfcUXp4VchbqJhLY5mxIJc/A==", "0361a537-739a-4c2b-aa3c-54dd55b961cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "426c343e-fcd2-40e9-92b9-fb064fc02a38", "AQAAAAEAACcQAAAAENPBoBiNULK7ztbTwjMvfqLjohJgpaSJ9dAh4zoQ1joOeiRwZS55fzvwoHZlEJziWw==", "8c9f47de-9ada-4428-88f4-3a79c85f68b7" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 45, 58, 303, DateTimeKind.Local).AddTicks(3465));
        }
    }
}
