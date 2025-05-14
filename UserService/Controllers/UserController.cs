using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	// GET: api/User
	[HttpGet]
	public ActionResult<IEnumerable<User>> GetAll()
	{
		var users = _userService.GetAll();
		return Ok(users);
	}

	// GET: api/User/{id}
	[HttpGet("{id}")]
	public ActionResult<User> GetById(Guid id)
	{
		var user = _userService.GetById(id);
		if (user == null)
			return NotFound();
		return Ok(user);
	}

	// POST: api/User
	[HttpPost]
	public IActionResult Create([FromBody] User user)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		_userService.Create(user);
		return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
	}

	// PUT: api/User/{id}
	[HttpPut("{id}")]
	public IActionResult Update(Guid id, [FromBody] User updatedUser)
	{
		var user = _userService.GetById(id);
		if (user == null)
			return NotFound();

		user.Username = updatedUser.Username;
		user.Email = updatedUser.Email;
		user.Role = updatedUser.Role;

		return Ok(user);
	}

	// DELETE: api/User/{id}
	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		var user = _userService.GetById(id);
		if (user == null)
			return NotFound();

		_userService.Delete(id);
		return NoContent();
	}
}
