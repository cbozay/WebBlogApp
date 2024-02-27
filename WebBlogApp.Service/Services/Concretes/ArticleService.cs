using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Data.UnitOfWorks;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Entity.ViewModels.Articles;
using WebBlogApp.Service.Services.Abstractions;

namespace WebBlogApp.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<ArticleVM>> GetAllArticlesAsync()
        {
            var articles= await unitOfWork.GetRepository<Article>().GetAllAsync();
            var map=mapper.Map<List<ArticleVM>>(articles);
            return map;
        }
    }
}
