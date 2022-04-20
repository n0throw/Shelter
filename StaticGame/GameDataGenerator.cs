using ShelterData;
using StaticGame.Cryptography;
using StaticGame.Data;

namespace StaticGame;

public class GameDataGenerator
{
	private readonly ICryptography cryptographer;

	public GameDataGenerator()
		: this(new Cryptographer()) { }

	public GameDataGenerator(ICryptography cryptographer)
		=> this.cryptographer = cryptographer;

	public Game Generate(string key)
	{
		List<int> indexes = GetIndexes(cryptographer.Decode(key));

		return new(
			GetEnvironment(indexes.Take(2).ToList()),
			GetUsers(indexes.Skip(2).ToList()).ToList());
	}

	private List<int> GetIndexes(string key)
		=> Split(key, 8).
			Select(binKey => Convert.ToInt32(binKey, 10)).
			ToList();

	private Data.Environment GetEnvironment(List<int> indexes)
	{
		using (ShelterContext sc = new())
		{
			return new(sc.Disasters.ToList()[indexes[0]],
				sc.Shelters.ToList()[indexes[1]]);
		}
	}

	private IEnumerable<User> GetUsers(List<int> indexes)
	{
		using (ShelterContext sc = new())
		{
			for (int i = 0, j = 2; i < indexes.Count / 7; i++)
			{
				yield return new User(
					i,
					sc.SpecialConditions.ToList()[indexes[j++]],
					sc.Professions.ToList()[indexes[j++]],
					sc.Luggage.ToList()[indexes[j++]],
					sc.Biology.ToList()[indexes[j++]],
					sc.Hobbies.ToList()[indexes[j++]],
					sc.Health.ToList()[indexes[j++]],
					sc.Facts.ToList()[indexes[j++]]);
			}
		}
	}

	private IEnumerable<string> Split(string str, int chunkSize)
	{
		int chunkCount = str.Length / chunkSize;

		for (int i = 0; i < chunkCount; i++)
			yield return str.Substring(i * chunkSize, chunkSize);
	}
}