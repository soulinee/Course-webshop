using System;
using System.Text.Json.Serialization;

namespace CourseGatewayApi.Storage.Contracts;

public class EnrollmentStorageContract
{
   // [JsonPropertyName("id")]
    public string id { get; init; } = default!;

    public string KlantId { get; init; } = default!;
    public string CourseId { get; init; } = default!;
    public DateTime EnrolledAt { get; init; }

}
