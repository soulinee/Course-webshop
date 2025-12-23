using System;
using KlantenWebAPi.context;
using KlantenWebAPi.contracten;
using KlantenWebAPi.model;
using Microsoft.EntityFrameworkCore;

namespace KlantenWebAPi.repos;

public class KlantRepository : IKlantRepository
{
    public Task<KlantResponseContract> CreateAsync(KlantRequestContract klant)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<KlantResponseContract>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<KlantResponseContract?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, KlantRequestContract klant)
    {
        throw new NotImplementedException();
    }
}
