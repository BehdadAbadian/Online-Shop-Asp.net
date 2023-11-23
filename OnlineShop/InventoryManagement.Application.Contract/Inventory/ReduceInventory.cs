
namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    {
        public long ProductID { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderID { get; set; }
    }
}
