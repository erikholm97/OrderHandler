using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderHandler.Data
{
    public class Article
    {
        [Required]
        public int Id { get; set; }
        [Required]
            public int ArticleNumber { get; set; }
            [Required]
            public string ArticleName { get; set; }
            [Required]
            public int Price { get; set; }

        public int CreateArticle(Article articleToCreate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Articles.Add(articleToCreate);

                db.SaveChanges();

                return articleToCreate.Id;
            }
        }
    }
}
