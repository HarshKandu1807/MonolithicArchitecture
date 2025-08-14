using Application.DTOS;
using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProduct _repo;
        public ProductService(IProduct repo) => _repo = repo;

        public async Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default)
            => (await _repo.GetAllAsync(ct))
                .Select(p => new ProductDto(p.Id, p.Name, p.Price))
                .ToList();

        public async Task<int> CreateAsync(string name, decimal price, CancellationToken ct = default)
        {
            var product = new Product(name, price);   // domain enforces rules
            await _repo.AddAsync(product, ct);
            await _repo.SaveChangesAsync(ct);
            return product.Id;
        }
    }
}
