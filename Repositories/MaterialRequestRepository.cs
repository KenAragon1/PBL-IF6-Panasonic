using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using panasonic.Models;

namespace panasonic.Repositories;

public interface IMaterialRequestRepository
{
    Task<List<MaterialRequest>> GetAllAsync();
    Task<List<MaterialRequest>> GetAllByCondition(Expression<Func<MaterialRequest, bool>> predicate);
    Task<MaterialRequest> GetAsync(int id);
    Task StoreAsync(MaterialRequest materialRequest);
    Task StoreManyAsync(List<MaterialRequest> materialRequests);
    Task UpdateAsync(MaterialRequest materialRequest);

    Task DeleteAsync(int id);

    IQueryable<MaterialRequest> Query();

    Task SaveChangesAsync();
}

public class MaterialRequestRepository : IMaterialRequestRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MaterialRequestRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<MaterialRequest>> GetAllAsync()
    {
        return await _dbContext.MaterialRequests.Include(mr => mr.Material).Include(mr => mr.RequestedBy)
        .Include(mr => mr.VerifiedBy)
        .Include(mr => mr.ApprovedBy)
        .Include(mr => mr.RejectedBy)
        .Include(mr => mr.ProductionLine)
        .OrderByDescending(mr => mr.CreatedAt)
        .ToListAsync();
    }

    public async Task<List<MaterialRequest>> GetAllByCondition(Expression<Func<MaterialRequest, bool>> predicate)
    {
        return await _dbContext.MaterialRequests.OrderByDescending(mr => mr.CreatedAt).Where(predicate).Include(mr => mr.Material).Include(mr => mr.RequestedBy)
        .Include(mr => mr.VerifiedBy).Include(mr => mr.ApprovedBy).Include(mr => mr.RejectedBy).Include(mr => mr.ProductionLine).ToListAsync();
    }

    public async Task<MaterialRequest> GetAsync(int id)
    {
        return await _dbContext.MaterialRequests.Include(mr => mr.Material).FirstOrDefaultAsync(mr => mr.Id == id);
    }

    public IQueryable<MaterialRequest> Query()
    {
        return _dbContext.MaterialRequests.AsQueryable();
    }

    public async Task StoreAsync(MaterialRequest materialRequest)
    {
        await _dbContext.MaterialRequests.AddAsync(materialRequest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task StoreManyAsync(List<MaterialRequest> materialRequests)
    {
        _dbContext.MaterialRequests.AddRange(materialRequests);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(MaterialRequest materialRequest)
    {
        _dbContext.MaterialRequests.Update(materialRequest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var request = await _dbContext.MaterialRequests.FirstAsync(mr => mr.Id == id);
        _dbContext.MaterialRequests.Remove(request);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}