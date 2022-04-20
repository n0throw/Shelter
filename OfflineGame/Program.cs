using ShelterData;
using ShelterData.Data;

using ShelterContext sc = new();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

static IResult GetData<T>(T? card, int id)
{
    if (card is null)
        return Results.NotFound(new
        {
            message = $"Card {typeof(T).Name} with id {id} not found"
        });

    return Results.Json(card);
}

app.MapGet("/api/SpecialConditions", () => sc.SpecialConditions.ToList());
app.MapGet("/api/SpecialConditions/{id}", (int id) =>
    GetData(sc.SpecialConditions.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Professions", () => sc.Professions.ToList());
app.MapGet("/api/Professions/{id}", (int id) =>
    GetData(sc.Professions.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Disasters", () => sc.Disasters.ToList());
app.MapGet("/api/Disasters/{id}", (int id) =>
    GetData(sc.Disasters.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Shelters", () => sc.Shelters.ToList());
app.MapGet("/api/Shelters/{id}", (int id) =>
    GetData(sc.Shelters.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Luggage", () => sc.Luggage.ToList());
app.MapGet("/api/Luggage/{id}", (int id) =>
    GetData(sc.Luggage.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Biology", () => sc.Biology.ToList());
app.MapGet("/api/Biology/{id}", (int id) =>
    GetData(sc.Biology.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Hobbies", () => sc.Hobbies.ToList());
app.MapGet("/api/Hobbies/{id}", (int id) =>
    GetData(sc.Hobbies.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Health", () => sc.Health.ToList());
app.MapGet("/api/Health/{id}", (int id) =>
    GetData(sc.Health.
        ToList().
        FirstOrDefault(card => card.Id == id), id));

app.MapGet("/api/Facts", () => sc.Facts.ToList());
app.MapGet("/api/Facts/{id}", (int id) =>
    GetData(sc.Facts.
        ToList().
        FirstOrDefault(card => card.Id == id), id));



app.MapPost("/api/Facts", (Fact fact) =>
{
    Fact output = fact with
    {
        Id = sc.Facts.Count() + 1
    };
    sc.Facts.Add(output);

    return output;
});

app.Run();

