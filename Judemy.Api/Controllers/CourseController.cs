using Judemy.Application.Interfaces;
using Judemy.Domain.Entity;
using Judemy.Domain.Entity.Users;
using Judemy.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using NuGet.Protocol;

namespace Judemy.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private IUnitOfWork _unitOfWork;
		public CourseController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpPost]
		[Authorize]
		public async Task<List<Course>> GetCourseByCategory(IDictionary<string, string> category)
		{
			return await _unitOfWork.Course.GetCourseByCategoryAsync(category.Values.First());
		}
		[HttpPost]
		[Authorize]
		[Route("Add")]
		public async Task<StatusCodeResult> AddCourse([FromBody] Course course)
		{
			await _unitOfWork.Course.CreateAsync(course);
			await _unitOfWork.Save();
			return Ok();
		}
	}
}

