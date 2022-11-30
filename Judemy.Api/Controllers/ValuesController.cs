using Microsoft.AspNetCore.Mvc;

namespace Judemy.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		[HttpPost]
		StatusCodeResult Test()=> Ok();
	}
}
