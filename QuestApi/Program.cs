using Microsoft.EntityFrameworkCore;
using QuestApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuestDb>(opt => opt.UseInMemoryDatabase("QuestList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/questitems", async (QuestDb db) =>
    await db.Quests.ToListAsync());

app.MapGet("/questitems/{id}", async (int id, QuestDb db) =>
    await db.Quests.FindAsync(id)
        is Quest quest
            ? Results.Ok(quest)
            : Results.NotFound());

app.MapPost("/questitems", async (Quest quest, QuestDb db) =>
{
    db.Quests.Add(quest);
    await db.SaveChangesAsync();

    return Results.Created($"/questitems/{quest.Id}", quest);
});


app.Run();
