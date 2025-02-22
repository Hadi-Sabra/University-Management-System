using Core.Features.Student.Commands.EnrollInCourse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ProjectName.API.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{studentId}/courses/{courseId}/enroll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EnrollInCourse(Guid studentId, Guid courseId)
    {
        var command = new EnrollInCourseCommand
        {
            StudentId = studentId,
            CourseId = courseId
        };
        
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(ODataQueryOptions<StudentDto> options)
    {
        var query = new GetStudentsQuery();
        var students = await _mediator.Send(query);
        return Ok(options.ApplyTo(students.AsQueryable()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
    {
        var query = new GetStudentByIdQuery { Id = id };
        var student = await _mediator.Send(query);
        return Ok(student);
    }

    [HttpGet("{studentId}/courses")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetStudentCourses(Guid studentId, ODataQueryOptions<CourseDto> options)
    {
        var query = new GetStudentCoursesQuery { StudentId = studentId };
        var courses = await _mediator.Send(query);
        return Ok(options.ApplyTo(courses.AsQueryable()));
    }

    [HttpGet("{studentId}/grades")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentGradeSummaryDto>> GetStudentGrades(Guid studentId)
    {
        var query = new GetStudentGradesQuery { StudentId = studentId };
        var grades = await _mediator.Send(query);
        return Ok(grades);
    }
}
