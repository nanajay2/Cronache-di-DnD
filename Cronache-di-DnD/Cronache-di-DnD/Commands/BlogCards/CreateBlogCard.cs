using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public record CreateBlogCard(string Title, DateTime Date, string Content) : IRequest<ActionResult<Guid>>;