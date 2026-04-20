using System;

namespace CourseGatewayApi.Contracts;

public class ConfirmCheckoutRequest
{

    public string UserId { get; set; } = default!;
    public List<string> CourseIds { get; set; } = new();
}
