using _01_ShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        //private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
          //  _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetDetails(id);
        }
        //public IActionResult OnPost(AddComment command, string productSlug)
        public IActionResult OnPost(string productSlug)
        {
           // command.Type = CommentType.Product;
          // var result = _commentApplication.Add(command);
            return RedirectToPage("/Product", new { Id = productSlug });
        }
    }
}
