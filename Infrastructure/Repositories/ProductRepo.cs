using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext db) => _db = db;

        public Task<List<Product>> GetAllAsync(CancellationToken ct = default)
            => _db.Products.AsNoTracking().ToListAsync(ct);

        public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task AddAsync(Product product, CancellationToken ct = default)
            => await _db.Products.AddAsync(product, ct);

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
