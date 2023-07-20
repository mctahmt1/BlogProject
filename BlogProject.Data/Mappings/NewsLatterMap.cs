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
	public class NewsLatterMap : IEntityTypeConfiguration<NewsLatter>
	{
		public void Configure(EntityTypeBuilder<NewsLatter> builder)
		{
			builder.HasData(new NewsLatter
			{
				Id = Guid.Parse("D0BF49E9-1983-4E9B-8E1F-C2BF02C95417"),
				Mail = "macitahmet65@gmail.com",
			});
		}
	}
}
