using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public class DeleteBlogCardHandler : IRequestHandler<DeleteBlogCard, ActionResult>
{
    private readonly AppDbContext _context;

    public DeleteBlogCardHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Handle(DeleteBlogCard request, CancellationToken cancellationToken)
    {
        var blogCard = await _context.BlogCards.FindAsync(new object[] { request.Id }, cancellationToken);
        if (blogCard == null) return new EmptyResult();

        _context.BlogCards.Remove(blogCard);
        await _context.SaveChangesAsync(cancellationToken);

        return new AcceptedResult();
    }
}