using System;
using CourseGatewayApi.Contracts;

namespace CourseGatewayApi.Interfaces;

public interface IEnrollmentService
{
     Task EnrollAsync(EnrollmentRequestContract request);
    Task<DashboardResponseContract> 
        GetDashboardAsync(string klantId);

}
