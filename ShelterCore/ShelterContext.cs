using Microsoft.EntityFrameworkCore;
using ShelterCore.Data;

namespace ShelterCore;

public class ShelterContext : DbContext
{
    public DbSet<SpecialConditionData> SpecialConditions => Set<SpecialConditionData>();
    public DbSet<ProfessionData> Professions => Set<ProfessionData>();
    public DbSet<DisasterData> Disasters => Set<DisasterData>();
    public DbSet<ShelterData> Shelters => Set<ShelterData>();
    public DbSet<LuggageData> Luggage => Set<LuggageData>();
    public DbSet<BiologyData> Biology => Set<BiologyData>();
    public DbSet<HobbieData> Hobbies => Set<HobbieData>();
    public DbSet<HealthData> Health => Set<HealthData>();
    public DbSet<FactData> Facts => Set<FactData>();

    private static readonly Random random = new();

    public ShelterContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=AppData.db");

    internal List<T> GetShuffleData<T>()
    {
        List<T> output = (List<T>)Convert.ChangeType(
            typeof(T).Name switch
            {
                "SpecialConditions" =>
                    FYShuffle(SpecialConditions.ToList()),
                "Professions" =>
                    FYShuffle(Professions.ToList()),
                "Disasters" =>
                    FYShuffle(Disasters.ToList()),
                "Shelters" =>
                    FYShuffle(Shelters.ToList()),
                "Luggage" =>
                    FYShuffle(Luggage.ToList()),
                "Biology" =>
                    FYShuffle(Biology.ToList()),
                "Hobbies" =>
                    FYShuffle(Hobbies.ToList()),
                "Health" =>
                    FYShuffle(Health.ToList()),
                "Facts" =>
                    FYShuffle(Facts.ToList()),
                _ => throw new NotImplementedException(typeof(T).Name)
            }, typeof(List<T>));

        return output;
    }

    private static List<T> FYShuffle<T>(List<T> dbElements)
    {
        for (int i = dbElements.Count - 1, j = random.Next(i + 1); i >= 1; i--, j = random.Next(i + 1))
            (dbElements[i], dbElements[j]) = (dbElements[j], dbElements[i]);

        return dbElements;
    }

    private static void Swap<T>(ref T el1, ref T el2) => (el1, el2) = (el2, el1);
}

