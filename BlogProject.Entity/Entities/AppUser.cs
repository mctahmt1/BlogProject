using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Entity.Entities
{
    public class AppUser : IdentityUser<Guid> , IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("c309ea09-f56a-4c5b-90ce-2bb87d3c4f59");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
