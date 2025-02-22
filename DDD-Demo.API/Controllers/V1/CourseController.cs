using Core.Features.Courses.Commands.CreateCourse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ProjectName.API.Controllers.V1;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var courseId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCourse), new { id = courseId }, courseId);
    }

    [HttpGet]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(ODataQueryOptions<CourseDto> options)
    {
        var query = new GetCoursesQuery();
        var courses = await _mediator.Send(query);
        return Ok(options.ApplyTo(courses.AsQueryable()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
    {
        var query = new GetCourseQuery { Id = id };
        var course = await _mediator.Send(query);
        return Ok(course);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        await _mediator.Send(new DeleteCourseCommand { Id = id });
        return NoContent();
    }
}