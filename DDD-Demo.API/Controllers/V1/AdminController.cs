using Core.DTOs;
using Core.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ProjectName.API.Controllers.V1;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("users")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
    }

    [HttpGet("users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> GetUser(Guid id)
    {
        var query = new GetUserByIdQuery { Id = id };
        var user = await _mediator.Send(query);
        return Ok(user);
    }

    [HttpGet("users")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(ODataQueryOptions<UserDto> options)
    {
        var query = new GetUsersQuery();
        var users = await _mediator.Send(query);
        return Ok(options.ApplyTo(users.AsQueryable()));
    }

    [HttpPost("academic-periods")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateAcademicPeriod([FromBody] CreateAcademicPeriodCommand command)
    {
        var periodId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAcademicPeriod), new { id = periodId }, periodId);
    }

    [HttpGet("academic-periods/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AcademicPeriodDto>> GetAcademicPeriod(Guid id)
    {
        var query = new GetAcademicPeriodQuery { Id = id };
        var period = await _mediator.Send(query);
        return Ok(period);
    }

    [HttpGet("academic-periods")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AcademicPeriodDto>>> GetAcademicPeriods(ODataQueryOptions<AcademicPeriodDto> options)
    {
        var query = new GetAcademicPeriodsQuery();
        var periods = await _mediator.Send(query);
        return Ok(options.ApplyTo(periods.AsQueryable()));
    }

    [HttpGet("statistics/enrollment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<EnrollmentStatisticsDto>> GetEnrollmentStatistics()
    {
        var query = new GetEnrollmentStatisticsQuery();
        var statistics = await _mediator.Send(query);
        return Ok(statistics);
    }

    [HttpGet("statistics/grades")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GradeStatisticsDto>> GetGradeStatistics()
    {
        var query = new GetGradeStatisticsQuery();
        var statistics = await _mediator.Send(query);
        return Ok(statistics);
    }
}
