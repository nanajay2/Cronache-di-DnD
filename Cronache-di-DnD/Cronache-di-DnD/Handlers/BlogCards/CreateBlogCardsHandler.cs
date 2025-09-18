using Cronache_di_DnD.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public class CreateBlogCardHandler : IRequestHandler<CreateBlogCard, ActionResult<Guid>>
{
    private readonly AppDbContext _context;

    public CreateBlogCardHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<Guid>> Handle(CreateBlogCard request, CancellationToken cancellationToken)
    {
        
        var entity = new BlogCardEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Date = request.Date,
            Content = request.Content
        };

        _context.BlogCards.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}