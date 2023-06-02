using BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);//Database de bulunan propertylerin Configürasyon ayarlarının yapıldığı kısımdır.
            //Data Seedleme; Veritabanına çalışmak için veriler ekleme işlemidir.
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.NET Core Deneme Makalesi",
                Content = "Neden Uygulamalarımızı Monitoring Etmeliyiz?\r\nİlk olarak bu sorunun cevabını vererek başlayalım. Nasıl ki insanlar, sağlık durumları için periyodik olarak doktor muayenesinden geçiyorlarsa benzer mantıkla yayın sürecindeki yazılımlar içinde bu periyodik muayene kesinlikle olmazsa olmazlardandır. Nihayetinde yazılımlar da tıpkı insanlar gibi canlı bir organizmadır ve süreç içerisinde farklı sebeplerden dolayı krizler, çöküşler ve hatta ölümler yaşayabilmektedirler. Bu sebepler, bir üstteki paragrafta saydığımız birkaç hususla beraber ayriyeten kontrolsüz bellek kullanımından doğan sıkıntılar, yetersiz disk alanından kaynaklı çöküşler vs. olabilmektedirler. İşte bu tarz işlevselliği sonlandırıcı durumları yönetebilmek için öncelikle bu durumlardan haberdar olmamız gerekmektedir. Bunun için ilgili yazılımların ne durumda olduğu bilgisini veren api’lar oluşturulmalı ve bu api’ları dinleyerek bizlere görsel veri sağlayan monitoring yapıları kullanılmalıdır. Böylece anlık olarak yazılımlar üzerinde oluşabilecek durumları daha dinamik takip edebilme ve gerektiği taktirde alınması gereken aksiyonları fazla kayba ve maliyete mahal vermeksizin alabilecek fırsatı kendimize sağlamış olmalıyız.\r\n\r\nAsp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?",
                ViewCount = 15,
                CategoryId = Guid.Parse("C7BE87F1-F43B-46A5-A236-828105C960E8"),
                ImageId = Guid.Parse("D0BF49E9-1983-4E9B-8E1F-C2BF02C95417"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("5CA6B261-E32D-4D26-9719-A98781F37011")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi",
                Content = "Asp.NET Core Health Check Nedir? Neden Bunu Tercih Etmeliyiz?\r\nYukarıda monitoring’in öneminden bahsettik. Eğer ki, Asp.NET Core mimarisinde bir yazılım yahut servis geliştiriyorsanız hızlı bir şekilde Health Check özelliğiyle sağlık kontrolü yapabileceğiniz bir mekanizma oluşturabilir ve bunu monitoring edebilirsiniz. Health Check mekanizması, ilgili yazılımın sağlık durumuna dair bilgi verirken bu işlemi uygulamadaki iş kuralı gereği devreye sokulmuş middleware’leri ve log mekanizmalarını tetiklemeksizin gerçekleştirmektedir. İşte bu özellik ilgili mekanizmanın etkisini kat be kat arttırmaktadır. Nihayetinde bizler bir uygulamanın ayakta olup olmadığını kontrol edebilmek için herhangi bir api’sini tetiklediğimizde Asp.NET Core mimarisinin pipeline’ı devreye girecek ve sonuç dönene kadar devreye sokulmuş olan tüm middleware’ler bir yandan tetiklenirken bir yandan da varsa log mekanizması çalışıp ilgili tabloya lüzumsuz bir kayıt eklenecektir. Oysa Asp.NET Core Health Check mekanizması sayesinde tüm middleware ve log yapıları es geçilip direkt uygulamanın sağlığı check edilecek ve duruma göre bilgi döndürülecektir. Böylece ateşi çıkmış bir çocuğun ateşini ölçmek için nasıl ki lüzumsuz yere dişlerini yahut kulaklarını kontrol etmeksizin direkt ateşini ölçüyorsak benzer mantıkla sağlık kontrolü yapılacak yazılımında farklı noktalarını tetiklemeksizin direkt sağlık kontrolünü nokta atış sağlamış oluyoruz. Muazzam değil mi?",
                ViewCount = 15,
                CategoryId = Guid.Parse("DDE199E6-19A4-4AC9-B400-16E77244088C"),
                ImageId = Guid.Parse("F7DFBBF2-BAC9-47F6-8671-DC3D5D2085B0"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("C85F48CF-6974-4E26-9489-4D3DA1E1505A")
            });
        }
    }
}
