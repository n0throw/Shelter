namespace ShelterCore.Data;

public record struct WorldData(
    ShelterData Shelter,
    DisasterData Disaster);
