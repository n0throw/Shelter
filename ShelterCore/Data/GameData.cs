namespace ShelterCore.Data;

public readonly record struct GameData(
    WorldData WorldData,
    List<UserData> UsersData);
