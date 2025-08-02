using CorderoDanielJoseAntonioPruebaTecnica.Data;
using CorderoDanielJoseAntonioPruebaTecnica.DTOs;
using CorderoDanielJoseAntonioPruebaTecnica.Models;
using CorderoDanielJoseAntonioPruebaTecnica.Settings;
using Microsoft.EntityFrameworkCore;

namespace CorderoDanielJoseAntonioPruebaTecnica.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) => _context = context;

        public async Task<int> CreateAsync(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Nombre = dto.Nombre,
                DescripcionEncriptada = AesEncryptionHelper.Encrypt(dto.Descripcion),
                Precio = dto.Precio,
                Stock = dto.Stock
            };

            _context.Productos.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<ProductReadDTO?> GetByIdAsync(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            return p == null ? null : new ProductReadDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = AesEncryptionHelper.Decrypt(p.DescripcionEncriptada),
                Precio = p.Precio,
                Stock = p.Stock
            };
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllAsync()
        {
            return await _context.Productos
                .Select(p => new ProductReadDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = AesEncryptionHelper.Decrypt(p.DescripcionEncriptada),
                    Precio = p.Precio,
                    Stock = p.Stock
                }).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, ProductCreateDTO dto)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product == null) return false;

            product.Nombre = dto.Nombre;
            product.DescripcionEncriptada = AesEncryptionHelper.Encrypt(dto.Descripcion);
            product.Precio = dto.Precio;
            product.Stock = dto.Stock;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product == null) return false;

            _context.Productos.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
