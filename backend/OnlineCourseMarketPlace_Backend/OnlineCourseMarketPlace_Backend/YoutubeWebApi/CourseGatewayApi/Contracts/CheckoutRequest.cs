using System;
using CourseGatewayApi.Models;

namespace CourseGatewayApi.Contracts;

public class CheckoutRequest
{
     public List<CheckoutCourse> Items { get; set; } = new();

}
