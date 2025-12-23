using System;
using KlantenWebAPi.context;
using KlantenWebAPi.contracten;
using KlantenWebAPi.mappers;
using KlantenWebAPi.model;
using Microsoft.EntityFrameworkCore;

namespace KlantenWebAPi.repos;

public class KlantRepository : IKlantRepository
{
    private readonly Dictionary<Guid, Klant> _klanten
        = new();
    public Task<KlantResponseContract> CreateAsync(KlantRequestContract klant)
    {
        var klantEntity = klant.MapToEntity();
        
        _klanten.Add(klantEntity.Id, klantEntity);
         var response = klantEntity.MapToResponse();
         return Task.FromResult(response);
    }

    public Task DeleteAsync(Guid id)
    {
        _klanten.Remove(id);
        return Task.FromResult(0);
    }

    public Task<List<KlantResponseContract>> GetAllAsync()
    {
       var response = _klanten.Values
        .Select(k => k.MapToResponse())
        .ToList();

        return Task.FromResult(response);
    }

    public Task<KlantResponseContract?> GetByIdAsync(Guid id)
    {
         if (!_klanten.TryGetValue(id, out var klant))
        {
            return Task.FromResult<KlantResponseContract?>(null);
        }

        var response = klant.MapToResponse();
        return Task.FromResult<KlantResponseContract?>(response);
    }

    public Task UpdateAsync(Guid id, KlantRequestContract klant)
    {
          if (!_klanten.TryGetValue(id, out var existingKlant))
    {
        // niets updaten → service/controller beslist wat dit betekent
        return Task.CompletedTask;
    }

    existingKlant.VolledigeNaam = klant.VolledigeNaam;
    existingKlant.Emailadres   = klant.Emailadres;
    existingKlant.Wachtwoord   = klant.Wachtwoord;

    return Task.CompletedTask;
    }
}
