using System;
using KlantenWebAPi.contracten;
using KlantenWebAPi.model;

namespace KlantenWebAPi.mappers;

public static class KlantMapper
{
     public static Klant MapToEntity(this KlantRequestContract request)
    {
        return new Klant
        {
            Id = Guid.NewGuid(),
            VolledigeNaam = request.VolledigeNaam,
            Emailadres = request.Emailadres,
            Wachtwoord = request.Wachtwoord
        };
    }

    public static KlantResponseContract MapToResponse(this Klant klant)
    {
        return new KlantResponseContract
        {
            Id = klant.Id,
            VolledigeNaam = klant.VolledigeNaam,
            Emailadres = klant.Emailadres
        };
    }

}
