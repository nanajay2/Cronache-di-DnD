using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.BlogCards;

public record DeleteBlogCard(Guid Id) : IRequest<ActionResult>;