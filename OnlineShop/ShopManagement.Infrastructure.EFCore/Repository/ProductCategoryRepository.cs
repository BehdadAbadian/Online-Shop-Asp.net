using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Linq.Expressions;


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

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaDescription =x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchmodel searchmodel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString()
              

            });
            if (!string.IsNullOrWhiteSpace(searchmodel.Name))
                query = query.Where(x => x.Name.Contains(searchmodel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
