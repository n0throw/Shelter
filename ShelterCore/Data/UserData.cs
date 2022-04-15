namespace ShelterCore.Data;

public record struct UserData(int Id, LuggageData Luggage, BiologyData Biology, HealthData Health, ProfessionData Profession, FactData Facts, HobbieData Hobbies, SpecialConditionData SpecialConditions);