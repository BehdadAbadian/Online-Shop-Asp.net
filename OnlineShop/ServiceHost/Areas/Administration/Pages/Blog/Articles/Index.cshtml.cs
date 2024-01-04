using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel Searchmodel;
        public List<ArticleViewModel> Articles;
        public SelectList ArticleCategories;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(),"Id","Name");
            Articles = _articleApplication.Search(searchModel);
        }

    }
}