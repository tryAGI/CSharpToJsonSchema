namespace CSharpToJsonSchema.MeaiTests.Services;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

public class StudentRecordService
{
    [System.ComponentModel.Description("Get student record for the year")]
    [FunctionTool(MeaiFunctionTool = true)]
    public async Task<StudentRecord> GetStudentRecordAsync(QueryStudentRecordRequest query,
        CancellationToken cancellationToken = default)
    {
        return new StudentRecord
        {
            StudentId = "12345",
            FullName = query.FullName,
            Level = StudentRecord.GradeLevel.Senior,
            EnrolledCourses = new List<string> { "Math 101", "Physics 202", "History 303" },
            Grades = new Dictionary<string, double>
            {
                { "Math 101", 3.5 },
                { "Physics 202", 3.8 },
                { "History 303", 3.9 }
            },
            EnrollmentDate = new DateTime(2020, 9, 1),
            IsActive = true
        };
    }

    [System.ComponentModel.Description("Get all student Records")]
    [FunctionTool(MeaiFunctionTool = true)]
    public async Task<List<StudentRecord>> GetStudentsListAsync(CancellationToken cancellationToken = default)
    {
        return new List<StudentRecord>
        {
            new StudentRecord
            {
                StudentId = "12345",
                FullName = "John Doe",
                Level = StudentRecord.GradeLevel.Senior,
                EnrolledCourses = new List<string> { "Math 101", "Physics 202", "History 303" },
                Grades = new Dictionary<string, double>
                {
                    { "Math 101", 3.5 },
                    { "Physics 202", 3.8 },
                    { "History 303", 3.9 }
                },
                EnrollmentDate = new DateTime(2020, 9, 1),
                IsActive = true
            },
            new StudentRecord
            {
                StudentId = "67890",
                FullName = "Jane Smith",
                Level = StudentRecord.GradeLevel.Junior,
                EnrolledCourses = new List<string> { "Biology 101", "Chemistry 202" },
                Grades = new Dictionary<string, double>
                {
                    { "Biology 101", 4.0 },
                    { "Chemistry 202", 3.7 }
                },
                EnrollmentDate = new DateTime(2019, 9, 1),
                IsActive = false
            }
        };
    }
    
    [System.ComponentModel.Description("Get all student Records")]
    [FunctionTool(MeaiFunctionTool = true)]
    public async Task<List<StudentRecord>> GetStudentsList2(CancellationToken cancellationToken = default)
    {
        return new List<StudentRecord>
        {
            new StudentRecord
            {
                StudentId = "12345",
                FullName = "John Doe",
                Level = StudentRecord.GradeLevel.Senior,
                EnrolledCourses = new List<string> { "Math 101", "Physics 202", "History 303" },
                Grades = new Dictionary<string, double>
                {
                    { "Math 101", 3.5 },
                    { "Physics 202", 3.8 },
                    { "History 303", 3.9 }
                },
                EnrollmentDate = new DateTime(2020, 9, 1),
                IsActive = true
            },
            new StudentRecord
            {
                StudentId = "67890",
                FullName = "Jane Smith",
                Level = StudentRecord.GradeLevel.Junior,
                EnrolledCourses = new List<string> { "Biology 101", "Chemistry 202" },
                Grades = new Dictionary<string, double>
                {
                    { "Biology 101", 4.0 },
                    { "Chemistry 202", 3.7 }
                },
                EnrollmentDate = new DateTime(2019, 9, 1),
                IsActive = false
            }
        };
    }
}

public class StudentRecord
{
    public enum GradeLevel
    {
        Freshman,
        Sophomore,
        Junior,
        Senior,
        Graduate
    }

    public string StudentId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public GradeLevel Level { get; set; } = GradeLevel.Freshman;
    public List<string> EnrolledCourses { get; set; } = new List<string>();
    public Dictionary<string, double> Grades { get; set; } = new Dictionary<string, double>();
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    public double CalculateGPA()
    {
        if (Grades.Count == 0) return 0.0;
        return Grades.Values.Average();
    }
}

[Description("Request class containing filters for querying student records.")]
public class QueryStudentRecordRequest
{
    [Description("The student's full name.")]
    public string FullName { get; set; } = string.Empty;

    [Description("Grade filters for querying specific grades, e.g., Freshman or Senior.")]
    public List<StudentRecord.GradeLevel> GradeFilters { get; set; } = new();

    [Description("The start date for the enrollment date range. ISO 8601 standard date")]
    public DateTime EnrollmentStartDate { get; set; }

    [Description("The end date for the enrollment date range. ISO 8601 standard date")]
    public DateTime EnrollmentEndDate { get; set; }

    [Description("The flag indicating whether to include only active students.")]
    public bool? IsActive { get; set; } = true;
}