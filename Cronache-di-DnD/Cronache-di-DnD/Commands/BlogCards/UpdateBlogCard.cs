using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public record UpdateBlogCard(Guid Id, string Title, DateTime Date, string Content) : IRequest<ActionResult>;