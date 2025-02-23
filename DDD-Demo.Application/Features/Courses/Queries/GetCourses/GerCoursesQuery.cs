using Core.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Core.Features.Courses.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<List<CourseDto>>
    {
       
    }
}