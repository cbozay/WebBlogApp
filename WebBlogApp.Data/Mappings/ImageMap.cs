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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = Guid.Parse("EFF96BAC-314D-4631-AED3-46961B5089D9"),
                    FileName = "CategoryImage",
                    FileType = "jpg",
                    CreatedBy = "Adimn",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Image
                {
                    Id = Guid.Parse("43C77E23-7230-45CB-9C3C-ECD240F0A90C"),
                    FileName = "CategoryImage1",
                    FileType = "jpg",
                    CreatedBy = "Adimn1",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                });
        }
    }
}
