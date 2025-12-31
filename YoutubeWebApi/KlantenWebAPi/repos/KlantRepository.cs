using System;
using KlantenWebAPi.context;
using KlantenWebAPi.contracten;
using KlantenWebAPi.mappers;
using KlantenWebAPi.model;
using Microsoft.EntityFrameworkCore;

namespace KlantenWebAPi.repos;

public class KlantRepository : IKlantRepository
{
    private readonly KlantDbContext _db;

    public KlantRepository(KlantDbContext db)
    {
        _db = db;
    }

   public async Task<KlantResponseContract> CreateAsync(KlantRequestContract klant)
{
    var entity = klant.MapToEntity();
    _db.Klanten.Add(entity);
    await _db.SaveChangesAsync();
    return entity.MapToResponse();
}

public async Task<bool> DeleteAsync(Guid id)
{
    var klant = await _db.Klanten.FindAsync(id);

    if (klant is null)
        return false; // nothing to delete

    _db.Klanten.Remove(klant);
    await _db.SaveChangesAsync();

    return true;
}


    public async Task<List<KlantResponseContract>> GetAllAsync()
    {
        return await _db.Klanten
            .Select(k => k.MapToResponse())
            .ToListAsync();
    }
   public async Task<KlantResponseContract?> GetByIdAsync(Guid id)
{
    var klant = await _db.Klanten.FindAsync(id);

    if (klant is null)
        return null;

    return klant.MapToResponse();
}

public async Task<bool> UpdateAsync(Guid id, KlantRequestContract klant)
{
    var existing = await _db.Klanten.FindAsync(id);

    if (existing is null)
        return false; // nothing to update

    existing.VolledigeNaam = klant.VolledigeNaam;
    existing.Emailadres    = klant.Emailadres;
    existing.Wachtwoord    = klant.Wachtwoord;

    await _db.SaveChangesAsync();
    return true;
}


}
