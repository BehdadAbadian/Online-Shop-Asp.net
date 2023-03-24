namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long ProductId { get; private set; }
        public string Product { get; set; }
        public int DiscountRate { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
        public string Reason { get; private set; }
    }
}
