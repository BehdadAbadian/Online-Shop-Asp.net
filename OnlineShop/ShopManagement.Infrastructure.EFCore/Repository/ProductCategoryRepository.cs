using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public void Create(ProductCategory entity)
        {
            _context.ProductCategories.Add(entity);
        }

        public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        {
            return _context.ProductCategories.Any(expression);
        }

        public ProductCategory Get(long id)
        {
            return _context.ProductCategories.Find(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public EditProductCategory GetDtails(long id)
        {
            return _context.ProductCategories.Select(X => new EditProductCategory()
            {
                Id = X.Id,
                Description = X.Description,
                Name = X.Name,
                Keywords = X.Keywords,
                MetaDescription =X.MetaDescription,
                Picture = X.Picture,
                PictureAlt = X.PictureAlt,
                PictureTitle = X.PictureTitle,
                Slug = X.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchmodel searchmodel)
        {
            throw new NotImplementedException();
        }
    }
}
