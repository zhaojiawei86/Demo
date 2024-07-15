using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controller;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly DataContext _dbContext;
  public UsersController(DataContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
  {
    var users = await _dbContext.Users.ToListAsync();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AppUser>> GetUserById(int id)
  {
    var user = await _dbContext.Users.FindAsync(id);
    if (user == null) return NotFound();
    return Ok(user);
  }
}
