using Store_GB_3.Models.Dto;

namespace Store_GB_3.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        int AddCategory(CategoryDto category);

    }
}
