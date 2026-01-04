using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Catalog.Infrastructure.Repositories;

internal class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
{
    private IRepository<Track>? _tracks;
    public IRepository<Track> Tracks => _tracks ??= new Repository<Track>(_context);

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.BeginTransactionAsync(cancellationToken);
    }
}
