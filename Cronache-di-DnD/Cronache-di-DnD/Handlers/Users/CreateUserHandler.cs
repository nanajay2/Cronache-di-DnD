using Cronache_di_DnD.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.Users;

public class CreateUserHandler : IRequestHandler<CreateUser, ActionResult<Guid>>
{
    private readonly AppDbContext _context;

    public CreateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<Guid>> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        
        var entity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            DM = request.DM
        };

        _context.Users.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}