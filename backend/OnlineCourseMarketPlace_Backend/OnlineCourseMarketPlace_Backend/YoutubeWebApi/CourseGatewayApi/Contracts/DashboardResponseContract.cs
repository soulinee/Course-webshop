namespace CourseGatewayApi.Contracts;

public record  DashboardResponseContract(
    string KlantId,
    string KlantNaam,
    List<DashboardCourseContract> Courses
);

