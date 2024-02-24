using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Entity.Entities;

namespace WebBlogApp.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("D8DBF00C-7769-4CF8-9756-2D72C96BC201"),
                Name = "CategoryNameDeneme",
                CreatedBy = "Admin Cat",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Category
            {
                Id = Guid.Parse("B47B6B64-ED3E-433B-B25E-D8C4B4F57BA1"),
                Name = "CategoryNameDeneme1",
                CreatedBy = "Admin Cat1",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
