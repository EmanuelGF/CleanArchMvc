using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    /// <summary>
    /// This is the interface for the product service.
    /// Will implement the contract for the CRUD operations.
    /// All methods will be async. (Task<T> and Task).
    /// Will make use of the DTO Objects.
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);

        Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(int? id);
    }
}

