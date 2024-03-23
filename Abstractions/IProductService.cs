using Store_GB_3.Models.Dto;

namespace Store_GB_3.Abstractions
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);

    }
}
