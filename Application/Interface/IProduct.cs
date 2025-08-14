using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetAllAsync(CancellationToken ct = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Product product, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
