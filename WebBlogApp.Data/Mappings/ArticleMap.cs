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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id=Guid.NewGuid(),
                Title="Asp.netCore deneme title",
                Content= "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title",
                ViewCount=15,
                ImageId= Guid.Parse("EFF96BAC-314D-4631-AED3-46961B5089D9"),
                CategoryId =Guid.Parse("D8DBF00C-7769-4CF8-9756-2D72C96BC201"),
                CreatedBy="Admin test",
                CreatedDate=DateTime.Now,
                IsDeleted=false,
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.netCore deneme title1",
                Content = "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1",
                ViewCount = 10,
                CategoryId= Guid.Parse("B47B6B64-ED3E-433B-B25E-D8C4B4F57BA1"),
                ImageId = Guid.Parse("43C77E23-7230-45CB-9C3C-ECD240F0A90C"),
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
