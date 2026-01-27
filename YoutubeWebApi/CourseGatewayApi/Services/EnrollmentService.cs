using System;
using CourseGatewayApi.Contracts;
using CourseGatewayApi.Interfaces;
using CourseGatewayApi.Repositories;
using CourseGatewayApi.Storage.Contracts;

namespace CourseGatewayApi.Services;

public class EnrollmentService(  IEnrollmentRepository repo, IKlantenClient klanten, IYoutubeClient youtube): IEnrollmentService
{
   public async Task EnrollAsync( EnrollmentRequestContract request)
    {
       // optioneel: validatie
        await klanten.GetKlantAsync(request.KlantId);
        await youtube.GetCourseAsync(request.CourseId);

        var record = new EnrollmentStorageContract
        {
            id = $"{request.KlantId}_{request.CourseId}", // ✅ uniek + stabiel
            KlantId = request.KlantId,                    // ✅ uit Postman
            CourseId = request.CourseId,                  // ✅ uit Postman
            EnrolledAt = DateTime.UtcNow
        };

        await repo.CreateAsync(record);


    }

    public async Task<DashboardResponseContract> GetDashboardAsync(string klantId)
{
    // 1. Haal klant op
    var klant = await klanten.GetKlantAsync(klantId);
    if (klant is null)
        throw new Exception("Klant niet gevonden");

    // 2. Haal enrollments uit Cosmos
    var enrollments = await repo.GetByKlantIdAsync(klantId);

    // 3. Haal courses via Youtube API
    var courses = new List<DashboardCourseContract>();

    foreach (var enrollment in enrollments)
    {
        var course = await youtube.GetCourseAsync(enrollment.CourseId);
        if (course is null) continue;

        courses.Add(new DashboardCourseContract(
            CourseId: course.Id,
            Title: course.Title,
            ThumbnailUrl: course.ThumbnailUrl
        ));
    }

    // 4. Bouw response
    return new DashboardResponseContract(
        KlantId: klant.Id,
        KlantNaam: klant.VolledigeNaam,
        Courses: courses
    );
}


}
