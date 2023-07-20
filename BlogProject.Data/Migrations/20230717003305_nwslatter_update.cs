using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class nwslatter_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("633e8fc9-aa1c-46cf-a551-e1f8e9f3f4c1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("df94bdd0-d010-410f-94f2-a51da6b75260"));

            migrationBuilder.DeleteData(
                table: "NewsLatters",
                keyColumn: "Id",
                keyValue: new Guid("c63642b9-5836-4e2f-af5b-bc625f6f4741"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewsLatters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsLatters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "NewsLatters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "NewsLatters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NewsLatters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NewsLatters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "NewsLatters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("58493917-0b68-4c1e-a33e-8abf277f6380"), new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(6469), null, null, new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), false, null, null, "Asp.NET Core Deneme Makalesi", new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 15 },
                    { new Guid("fdbbfe10-5448-47dd-b98f-c4df195b9068"), new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(6484), null, null, new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"),
                column: "ConcurrencyStamp",
                value: "a823522e-7b31-4cf1-b878-b4ee61736d67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("893c5295-04cc-47df-9c95-e6470ac0aece"),
                column: "ConcurrencyStamp",
                value: "6bd790d3-c829-4a01-94d5-65dc801f4ee9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"),
                column: "ConcurrencyStamp",
                value: "841b83c3-0ff8-4dfc-b485-0496ea78903c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14d1409c-3cb1-42cf-a625-3452716ba234", "AQAAAAEAACcQAAAAEMQkRoZqTg1rsD2e4LIpTACHL8QUYIehg5x5Cj0rIUAWFBBVo7pcKuidLKD+lZMTZw==", "4c873839-5c4f-44c0-a3a8-03f046b2c855" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fde3fdc8-8375-4545-aabc-ad993d44bf69", "AQAAAAEAACcQAAAAEIeX97VdGZPMezd7AVv0XoHidCpi8O1mukOlvH4I6rpamzZA5nSKgrD/7v7/FE2S/w==", "b2a57dea-af94-48ec-8dfe-efad20efd0e1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.InsertData(
                table: "NewsLatters",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Mail", "MailStatus", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), "Undefined", new DateTime(2023, 7, 17, 3, 33, 4, 327, DateTimeKind.Local).AddTicks(9128), null, null, false, "macitahmet65@gmail.com", true, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("58493917-0b68-4c1e-a33e-8abf277f6380"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fdbbfe10-5448-47dd-b98f-c4df195b9068"));

            migrationBuilder.DeleteData(
                table: "NewsLatters",
                keyColumn: "Id",
                keyValue: new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NewsLatters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "NewsLatters");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("633e8fc9-aa1c-46cf-a551-e1f8e9f3f4c1"), new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"), "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(116), null, null, new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"), 15 },
                    { new Guid("df94bdd0-d010-410f-94f2-a51da6b75260"), new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"), "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?", "Admin Test", new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(108), null, null, new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"), false, null, null, "Asp.NET Core Deneme Makalesi", new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42276a32-7d3a-47c9-8182-75e2ac90bffa"),
                column: "ConcurrencyStamp",
                value: "9a154b65-e2e5-461e-b395-b548ac2ced2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("893c5295-04cc-47df-9c95-e6470ac0aece"),
                column: "ConcurrencyStamp",
                value: "f57f3713-9b3b-4656-8e64-53d0b8fc3e5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab7e18a3-ea21-45b2-b7ef-1ed5e44f2911"),
                column: "ConcurrencyStamp",
                value: "6c8bf55b-0105-4b0e-9eb4-91f09b5626ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ca6b261-e32d-4d26-9719-a98781f37011"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82a056fe-bf4d-4389-a245-ad726de8d390", "AQAAAAEAACcQAAAAEHWg38o8YDppkA/TznKI6di3TtPYpegfezOpc38aDYOQRwgkBWmcqyzW3zDqB/z0/Q==", "2a66ab9b-1fa6-4f09-ac92-5b71311aee54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f48cf-6974-4e26-9489-4d3da1e1505a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b5828e6-9ced-4ef4-bfcb-90eaadce2e6d", "AQAAAAEAACcQAAAAEG/7+NZpINRfGJTyynvbJdvWodpOzgXpSafTcp2Q1F7jqcB3d+oxP1aqPPBjMBZAVQ==", "b5893bd1-12d0-4eb1-93e2-0d0e2b55d352" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7be87f1-f43b-46a5-a236-828105c960e8"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dde199e6-19a4-4ac9-b400-16e77244088c"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d0bf49e9-1983-4e9b-8e1f-c2bf02c95417"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f7dfbbf2-bac9-47f6-8671-dc3d5d2085b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 17, 2, 54, 19, 52, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.InsertData(
                table: "NewsLatters",
                columns: new[] { "Id", "Mail", "MailStatus" },
                values: new object[] { new Guid("c63642b9-5836-4e2f-af5b-bc625f6f4741"), "macitahmet65@gmail.com", true });
        }
    }
}
