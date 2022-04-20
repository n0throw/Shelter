using ShelterData.Data;

namespace StaticGame.Data;

public record struct Environment(
	Disaster Disaster,
	Shelter Shelter);