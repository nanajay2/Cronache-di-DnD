using Cronache_di_DnD.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.Users;

public record UpdateUser(Guid Id,
                         string Name, 
                         string Surname, 
                         string Email, 
                         bool DM) : IRequest<ActionResult>;
