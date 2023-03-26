using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _discountContext.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId, 

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var produts = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _discountContext.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id= x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
            
            
            }); 
            if(searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }
            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount => discount.Product = produts.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discounts;
        }
    }
}
