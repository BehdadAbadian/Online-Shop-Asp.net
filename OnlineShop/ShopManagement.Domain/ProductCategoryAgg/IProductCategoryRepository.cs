using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository :IRepository <long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        string GetSlugById(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchmodel searchmodel);
        
    }
}
