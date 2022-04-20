using ShelterData.Data;

namespace StaticGame.Data;

public record struct User(
	int Id,
	SpecialCondition SpecialCondition,
	Profession Profession,
	Luggage Luggage,
	Biology Biology,
	Hobbie Hobbie,
	Health Health,
	Fact Fact);