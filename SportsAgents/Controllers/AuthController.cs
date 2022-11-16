using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SportsAgents.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SportsAgents.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly SportsAgentsContext _context;

		public AuthController(SportsAgentsContext context)
		{
			_context = context;
		}

		private string CreateJWT(User user)
		{
			var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY"));  //TODO: guid do wrzucenia
			var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, user.Email)
			};
			var token = new JwtSecurityToken(issuer: "si.com", audience: "si.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		[HttpPost]
		[Route("Register")]
		public async Task<LoginResult> Post([FromBody] RegModel reg)
		{
			User newUser = new User
			{
				Login = reg.email,
				Password = reg.password,
				Email = reg.email,
				FullName = reg.fullname,
				Age = reg.age
			};

			if (reg.password != reg.confirmpwd)
            {
				return new LoginResult { message = "Password and confirm password do not match.", success = false };
			}

			_context.Add<User>(newUser);
			_context.SaveChanges();

			if (newUser != null)
            {
				return new LoginResult { message = "Registration successful.", jwtBearer = CreateJWT(newUser), email = reg.email, success = true };
			}

			return new LoginResult { message = "User already exists.", success = false };
		}

		[HttpPost]
		[Route("Login")]
		public async Task<LoginResult> Post([FromBody] LoginModel log)
		{
			var user = _context.Users
				.Where(u => u.Login == log.email && u.Password == log.password)
				.FirstOrDefault();

			if (user != null)
            {
				return new LoginResult { message = "Login successful.", jwtBearer = CreateJWT(user), email = log.email, success = true };
			}
			return new LoginResult { message = "User/password not found.", success = false };
		}
	}
}
