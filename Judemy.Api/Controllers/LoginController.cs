using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Judemy.Application.Interfaces;
using Judemy.Persistent.EntityTypeContext;
using Judemy.Domain.Entity.Users;

namespace Judemy.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IContext _context;
		private readonly IMapper _mapper;

		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly SignInManager<User> _signInManager;

		public LoginController(Context context, IMapper mapper,
			UserManager<User> userManager, RoleManager<Role> rolemanager, SignInManager<User> signInManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = rolemanager;
			_signInManager = signInManager;
		}
		[HttpPost]
		public async Task<string> Register(CreateUser user)
		{
			User? mapped = _mapper.Map<User>(user);
			if (ModelState.IsValid)
			{
				IdentityResult? result = await _userManager.CreateAsync(mapped, mapped.PasswordHash);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(mapped, true);
				}
			}

			return "OK";
		}
	}
}
