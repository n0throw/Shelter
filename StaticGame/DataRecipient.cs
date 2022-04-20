using ShelterData;

namespace StaticGame;

public static class DataRecipient
{
	private static readonly Random random = new();

	public static List<T> GetShuffleData<T>()
	{
		using (ShelterContext sc = new())
		{
			return (List<T>)Convert.ChangeType(
				typeof(T).Name switch
				{
					"SpecialConditions" =>
						FYShuffle(sc.SpecialConditions.ToList()),
					"Professions" =>
						FYShuffle(sc.Professions.ToList()),
					"Disasters" =>
						FYShuffle(sc.Disasters.ToList()),
					"Shelters" =>
						FYShuffle(sc.Shelters.ToList()),
					"Luggage" =>
						FYShuffle(sc.Luggage.ToList()),
					"Biology" =>
						FYShuffle(sc.Biology.ToList()),
					"Hobbies" =>
						FYShuffle(sc.Hobbies.ToList()),
					"Health" =>
						FYShuffle(sc.Health.ToList()),
					"Facts" =>
						FYShuffle(sc.Facts.ToList()),
					_ => throw new NotImplementedException(typeof(T).Name)
				}, typeof(List<T>));
		}
	}

	private static List<T> FYShuffle<T>(List<T> dbElements)
	{
		for (int i = dbElements.Count - 1, j = random.Next(i + 1); i >= 1; i--, j = random.Next(i + 1))
			(dbElements[i], dbElements[j]) = (dbElements[j], dbElements[i]);

		return dbElements;
	}
}

