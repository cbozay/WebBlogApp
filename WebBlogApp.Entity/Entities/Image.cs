﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Core.Entities;

namespace WebBlogApp.Entity.Entities
{
    public class Image : EntityBase
    {
        public string FileName{ get; set; }
        public string FileType{ get; set; }
        public ICollection<Article> Articles{ get; set; }
        public ICollection<AppUser> Users{ get; set; }
    }         
}
