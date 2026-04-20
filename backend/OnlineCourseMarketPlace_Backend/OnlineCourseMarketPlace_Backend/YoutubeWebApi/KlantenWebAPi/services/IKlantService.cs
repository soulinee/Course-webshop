using System;
using KlantenWebAPi.contracten;

namespace KlantenWebAPi.services;

public interface IKlantService
{
     Task<KlantResponseContract> CreateAsync(KlantRequestContract klant);
    Task<KlantResponseContract?> GetByIdAsync(Guid id);
    Task<List<KlantResponseContract>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, KlantRequestContract klant);
    Task<bool> DeleteAsync(Guid id);

}
