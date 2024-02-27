using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Entity.ViewModels.Articles;

namespace WebBlogApp.Service.AutoMapper.Articles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleVM,Article>().ReverseMap();
            //Article entity sini ArticleVM e map ledik(dönüştürdük).
            //ReverseMap ise ihtiyac halinde bu dönüşümü tersine çevirmektedir.
            //Yani ArticleVM entity sini Article ye map ler..
        }
    }
}
