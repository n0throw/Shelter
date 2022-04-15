using ShelterCore;
using ShelterCore.Data;

List<UserData> usersData = new(16);

for (int id = 1; id <= 16; id++)
        {
    usersData.Add(new()
    {
        Id = id,
        Luggage = new LuggageData(128, ""),
        Biology = new BiologyData(128, ""),
        Health = new HealthData(128, ""),
        Profession = new ProfessionData(128, ""),
        Facts = new FactData(128, ""),
        Hobbies = new HobbieData(128, ""),
        SpecialConditions = new SpecialConditionData(128, ""),
    });
}

GameData gd = new()
{
    WorldData = new WorldData()
    {
        Shelter = new ShelterData(128, ""),
        Disaster = new DisasterData(128, "")
    },
    UsersData = usersData
};

string key = new KeyGenerator().Generate(gd);
GameData newGD = new GameDataConverter().Convert(key);

Console.WriteLine(gd.Equals(newGD));

Console.ReadLine();
