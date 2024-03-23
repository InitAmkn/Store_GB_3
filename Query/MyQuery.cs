using Store_GB_3.Abstractions;
using Store_GB_3.Models.Dto;

namespace Store_GB_3.Query
{
    public class MyQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<StorageDto> GetStorage([Service] IStorageService service) => service.GetStorages();
        public IEnumerable<CategoryDto> GetCategory([Service] ICategoryService service) => service.GetCategories();


    }
}
