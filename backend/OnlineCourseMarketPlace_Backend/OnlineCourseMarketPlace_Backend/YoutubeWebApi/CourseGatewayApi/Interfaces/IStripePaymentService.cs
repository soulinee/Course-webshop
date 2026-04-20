using System;
using CourseGatewayApi.Contracts;

namespace CourseGatewayApi.Interfaces;

public interface IStripePaymentService
{
     string CreateCheckoutSession(CheckoutRequest request);

}
