using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cronache_di_DnD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionSummariesController : ControllerBase
{
    private static List<BlogCard> cards = new List<BlogCard>();

    [HttpGet]
    public ActionResult<List<BlogCard>> GetCards()
    {
        return cards;
    }

    [HttpPost]
    public ActionResult<BlogCard> AddCard(BlogCard newCard)
    {
        cards.Add(newCard);
        return CreatedAtAction(nameof(GetCards), null, newCard);
    }
}

public class BlogCard
{
    public string Title { get; set; }
    public string Text { get; set; }
    public DateOnly Date { get; set; }
}
