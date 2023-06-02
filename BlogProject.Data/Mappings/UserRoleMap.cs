using BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("5CA6B261-E32D-4D26-9719-A98781F37011"),
                RoleId = Guid.Parse("42276A32-7D3A-47C9-8182-75E2AC90BFFA")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("C85F48CF-6974-4E26-9489-4D3DA1E1505A"),
                RoleId = Guid.Parse("AB7E18A3-EA21-45B2-B7EF-1ED5E44F2911")
            });
        }
    }
}
