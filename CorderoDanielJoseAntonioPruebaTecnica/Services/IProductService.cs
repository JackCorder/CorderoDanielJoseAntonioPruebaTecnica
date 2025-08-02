using CorderoDanielJoseAntonioPruebaTecnica.DTOs;

namespace CorderoDanielJoseAntonioPruebaTecnica.Services
{
    public interface IProductService
    {
        Task<ProductReadDTO?> GetByIdAsync(int id);
        Task<IEnumerable<ProductReadDTO>> GetAllAsync();
        Task<int> CreateAsync(ProductCreateDTO dto);
        Task<bool> UpdateAsync(int id, ProductCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
