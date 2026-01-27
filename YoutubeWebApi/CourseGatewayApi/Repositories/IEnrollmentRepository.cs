using System;
using CourseGatewayApi.Storage.Contracts;

namespace CourseGatewayApi.Repositories;

public interface IEnrollmentRepository
{
     Task<EnrollmentStorageContract> CreateAsync(
        EnrollmentStorageContract contract);

    Task<List<EnrollmentStorageContract>> 
        GetByKlantIdAsync(string klantId);
        


}
