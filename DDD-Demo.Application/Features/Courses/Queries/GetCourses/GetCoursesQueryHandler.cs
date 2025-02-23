using Core.DTOs;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Courses.Queries.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetCoursesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Courses
                .Select(course => new CourseDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Code = course.Code,
                    MaximumStudents = course.MaximumStudents,
                    EnrollmentStartDate = course.EnrollmentStartDate,
                    EnrollmentEndDate = course.EnrollmentEndDate
                })
                .ToListAsync(cancellationToken);
        }
    }
}