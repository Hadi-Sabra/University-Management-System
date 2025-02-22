using Core.Features.Teacher.Commands.AddTimeSlot;
using Core.Features.Teacher.Commands.RegisterCourse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ProjectName.API.Controllers.V1;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeachersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{teacherId}/courses/{courseId}/register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterForCourse(Guid teacherId, Guid courseId)
    {
        var command = new RegisterForCourseCommand
        {
            TeacherId = teacherId,
            CourseId = courseId
        };
        
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{teacherId}/courses/{courseId}/timeslots")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddTimeSlot(Guid teacherId, Guid courseId, [FromBody] AddTimeSlotRequest request)
    {
        var command = new AddTimeSlotCommand
        {
            TeacherId = teacherId,
            CourseId = courseId,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };
        
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers(ODataQueryOptions<TeacherDto> options)
    {
        var query = new GetTeachersQuery();
        var teachers = await _mediator.Send(query);
        return Ok(options.ApplyTo(teachers.AsQueryable()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherDto>> GetTeacher(Guid id)
    {
        var query = new GetTeacherByIdQuery { Id = id };
        var teacher = await _mediator.Send(query);
        return Ok(teacher);
    }

    [HttpGet("{teacherId}/courses")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetTeacherCourses(Guid teacherId, ODataQueryOptions<CourseDto> options)
    {
        var query = new GetTeacherCoursesQuery { TeacherId = teacherId };
        var courses = await _mediator.Send(query);
        return Ok(options.ApplyTo(courses.AsQueryable()));
    }

    [HttpPost("{teacherId}/students/{studentId}/grades")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetStudentGrade(Guid teacherId, Guid studentId, [FromBody] SetGradeRequest request)
    {
        var command = new SetStudentGradeCommand
        {
            TeacherId = teacherId,
            StudentId = studentId,
            CourseId = request.CourseId,
            Grade = request.Grade
        };
        
        await _mediator.Send(command);
        return Ok();
    }
}
