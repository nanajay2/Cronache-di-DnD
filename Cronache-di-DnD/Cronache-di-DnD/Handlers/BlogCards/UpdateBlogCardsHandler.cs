using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public class UpdateBlogCardHandler : IRequestHandler<UpdateBlogCard, ActionResult?>
{
    private readonly AppDbContext _context;

    public UpdateBlogCardHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Handle(UpdateBlogCard request, CancellationToken cancellationToken)
    {
        var blogCard = await _context.BlogCards.FindAsync(new object[] { request.Id }, cancellationToken);
        if (blogCard == null) return null;

        blogCard.Title = request.Title;
        blogCard.Date = request.Date;
        blogCard.Content = request.Content;

        await _context.SaveChangesAsync(cancellationToken);
        return new AcceptedResult();
    }
}