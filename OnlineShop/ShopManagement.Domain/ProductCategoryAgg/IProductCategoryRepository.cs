using ShopManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
        bool Exists(Expression<Func<ProductCategory, bool>> expression);
        void SaveChanges();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchmodel searchmodel);
        
    }
}
