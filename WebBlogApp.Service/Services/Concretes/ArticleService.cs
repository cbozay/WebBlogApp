using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Data.UnitOfWorks;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Service.Services.Abstractions;

namespace WebBlogApp.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await unitOfWork.GetRepository<Article>().GetAllAsync();
        }
    }
}
