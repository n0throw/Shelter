using ShelterData;
using ShelterData.Data;
using StaticGame;

using ShelterContext sc = new();

KeyGenerator keyGenerator = new();
GameDataGenerator gameDataGenerator = new();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

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

app.MapGet("/api/GetKey/{playersCount}", (int playersCount) =>
{
    try
	{
        return Results.Json(keyGenerator.Generate(playersCount));
	}
    catch (ArgumentOutOfRangeException ex)
	{
        return Results.Problem(ex.Message, ex.ParamName, 416);
    }
});

app.MapGet("/api/GetGameData/{key}", (string key) =>
{
    try
    {
        return Results.Json(gameDataGenerator.Generate(key));
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, nameof(key), 404);
    }
});

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
