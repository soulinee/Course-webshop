using System;
using KlantenWebAPi.contracten;
using KlantenWebAPi.repos;

namespace KlantenWebAPi.services;

public class KlantService : IKlantService
{
     private readonly IKlantRepository _repo;

    public KlantService(IKlantRepository repo)
    {
        _repo = repo;
    }

    public async Task<KlantResponseContract> CreateAsync(KlantRequestContract klant)
    {
        if (string.IsNullOrWhiteSpace(klant.Emailadres))
            throw new ArgumentException("Emailadres mag niet leeg zijn");

        var created = await _repo.CreateAsync(klant);
        return created;
    }

    public Task<KlantResponseContract?> GetByIdAsync(Guid id)
        => _repo.GetByIdAsync(id);

    public Task<List<KlantResponseContract>> GetAllAsync()
        => _repo.GetAllAsync();

    public async Task<bool> UpdateAsync(Guid id, KlantRequestContract klant)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null)
            return false;

        await _repo.UpdateAsync(id, klant);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null)
            return false;

        await _repo.DeleteAsync(id);
        return true;
    }

}
