using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronache_di_DnD.Commands.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUser, ActionResult?>
{
    private readonly AppDbContext _context;

    public UpdateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        if (user == null) return null;

        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Email = request.Email;
        user.DM = request.DM;

        await _context.SaveChangesAsync(cancellationToken);
        return new AcceptedResult();
    }
}