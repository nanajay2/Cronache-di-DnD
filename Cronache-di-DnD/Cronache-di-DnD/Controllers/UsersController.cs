using Cronache_di_DnD.Commands;
using Cronache_di_DnD.Commands.Users;
using Cronache_di_DnD.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Cronache_di_DnD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UsersController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> Retrieve()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> RetrieveById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserEntity>> Create(CreateUserRequest user)
    {
        if (user is null) { return BadRequest(); }
        
        var created = new CreateUser(user.Name,
                                     user.Surname,
                                     user.Email,
                                     user.DM);
        
        var result = await _mediator.Send(created);
        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateUserRequest command)
    {
        if (id == null) return BadRequest();
        
        var updated = new UpdateUser(id, command.Name, command.Surname, command.Email, command.DM);
        
        var result = await _mediator.Send(updated);
        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok();
    }
    
    public record CreateUserRequest(string Name, string Surname, string Email, bool DM);
    public record UpdateUserRequest(string Name, string Surname, string Email, bool DM);
}