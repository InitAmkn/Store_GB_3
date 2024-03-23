
using Store_GB_3.Models.Dto;

namespace WebApi2.Abstractions
{
    public interface IWarehouseService
    {
        List<WarehouseItem> GetItems(int warehouseId);
    }
}
