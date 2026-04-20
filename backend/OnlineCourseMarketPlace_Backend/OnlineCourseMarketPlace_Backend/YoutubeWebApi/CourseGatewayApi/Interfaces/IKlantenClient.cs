using System;
using CourseGatewayApi.Contracts;

namespace CourseGatewayApi.Interfaces;

public interface IKlantenClient
{
    Task<KlantResponseContract?> GetKlantAsync(string klantId);

}
