using System;
using CourseGatewayApi.Contracts;
using CourseGatewayApi.Interfaces;

namespace CourseGatewayApi.Clients;

public class KlantenClient : IKlantenClient
{
    private readonly HttpClient _http;
    public KlantenClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<KlantResponseContract?> GetKlantAsync(string klantId)
    {
        return await _http.GetFromJsonAsync<KlantResponseContract>(
            $"api/klanten/{klantId}");
    }

}
