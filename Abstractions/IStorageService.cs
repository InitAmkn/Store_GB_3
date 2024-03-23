using Store_GB_3.Models.Dto;

namespace Store_GB_3.Abstractions
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetStorages();
        int AddStorage(StorageDto storage);

    }
}
