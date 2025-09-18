using Microsoft.AspNetCore.Mvc;
using Cronache_di_DnD.Commands.BlogCards;
using Cronache_di_DnD.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cronache_di_DnD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogCardsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public BlogCardsController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<BlogCardEntity>?> Retrieve()
    {
        var cards = await _context.BlogCards.ToListAsync();

        if (cards == null) return null;
        
        return cards;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogCardEntity>> RetrieveById(Guid id)
    {
        var card = await _context.BlogCards.FindAsync(id);
        if (card == null) return NotFound();
        return Ok(card);
    }

    [HttpPost]
    public async Task<ActionResult<BlogCardEntity>> Create(CreateBlogCardRequest card)
    {
        if (card is null) { return BadRequest(); }
        
        var created = new CreateBlogCard(card.Title, 
                                         card.Date,
                                         card.Content);
        
        var result = await _mediator.Send(created);
        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateBlogCardRequest command)
    {
        if (id == null) return BadRequest();
        
        var updated = new UpdateBlogCard(id, command.Title, command.Date, command.Content);
        
        var result = await _mediator.Send(updated);
        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        if (id == null) return BadRequest();
        
        var deleted = new DeleteBlogCard(id);
        
        var result = await _mediator.Send(deleted);
        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok();
    }
}

public record CreateBlogCardRequest(string Title, DateTime Date, string Content);
public record UpdateBlogCardRequest(string Title, DateTime Date, string Content);
