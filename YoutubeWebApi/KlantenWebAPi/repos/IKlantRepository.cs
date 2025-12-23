using System;
using KlantenWebAPi.contracten;
using KlantenWebAPi.model;

namespace KlantenWebAPi.repos;

public interface IKlantRepository
{
   Task<List<KlantResponseContract>> GetAllAsync();

    Task<KlantResponseContract?> GetByIdAsync(Guid id);

    Task<KlantResponseContract> CreateAsync(KlantRequestContract klant);

    Task UpdateAsync(Guid id, KlantRequestContract klant);

    Task DeleteAsync(Guid id);

}
