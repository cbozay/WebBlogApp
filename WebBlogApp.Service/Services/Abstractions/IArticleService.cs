using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Entity.ViewModels.Articles;

namespace WebBlogApp.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleVM>> GetAllArticlesAsync();
    }
}
