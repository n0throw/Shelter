using ShelterData.Data;
using StaticGame.Cryptography;
using StaticGame.Data;

namespace StaticGame;

public class KeyGenerator
{
	private const int minPlayersCount = 6;
	private const int maxPlayersCount = 16;
	private readonly ICryptography cryptographer;

	public KeyGenerator()
		: this(new Cryptographer()) { }

	public KeyGenerator(ICryptography cryptographer)
		=> this.cryptographer = cryptographer;

	public string Generate(int playersCount)
	{
		if (!ValidatePlayersCount(playersCount))
			throw new ArgumentOutOfRangeException(
				nameof(playersCount),
				"6-16",
				"Not the right number of players"
			);

		return GenerateKey(GetData(playersCount));
	}

	private bool ValidatePlayersCount(int playersCount)
	{
		if (playersCount < minPlayersCount || playersCount > maxPlayersCount)
			return false;
		return true;
	}

	private Game GetData(int playersCount)
		=> new(GetEnvironment(), GetUsers(playersCount));

	private Data.Environment GetEnvironment()
		=> new(
			DataRecipient.GetShuffleData<Disaster>().First(),
			DataRecipient.GetShuffleData<Shelter>().First()
		);

	// рефлексия?
	private List<User> GetUsers(int playersCount)
	{
		List<User> users = new(playersCount);

		List<SpecialCondition> specialConditions = DataRecipient.
			GetShuffleData<SpecialCondition>().
			GetRange(0, playersCount);

		List<Profession> professions = DataRecipient.
			GetShuffleData<Profession>().
			GetRange(0, playersCount);

		List<Luggage> luggage = DataRecipient.
			GetShuffleData<Luggage>().
			GetRange(0, playersCount);

		List<Biology> biology = DataRecipient.
			GetShuffleData<Biology>().
			GetRange(0, playersCount);

		List<Hobbie> hobbies = DataRecipient.
			GetShuffleData<Hobbie>().
			GetRange(0, playersCount);

		List<Health> health = DataRecipient.
			GetShuffleData<Health>().
			GetRange(0, playersCount);

		List<Fact> facts = DataRecipient.
			GetShuffleData<Fact>().
			GetRange(0, playersCount);


		for (int id = 1; id <= playersCount; id++)
		{
			users.Add(new()
			{
				Id = id,
				SpecialCondition = specialConditions[id - 1],
				Profession = professions[id - 1],
				Luggage = luggage[id - 1],
				Biology = biology[id - 1],
				Hobbie = hobbies[id - 1],
				Health = health[id - 1],
				Fact = facts[id - 1]
			});
		}

		return users;
	}

	/* Block key
     * one block - 8 bit (128 value)
     * 1. Disaster
     * 2. Bunker
     *
     * Next blocks playes data
     *
     * 3. SpecialConditions
     * 4. Professions
     * 5. Luggage
     * 6. Biology
     * 7. Hobbies
     * 8. Health
     * 9. Facts
     *
     * 10. Luggage playes 2
     * 11. etc...
     */
	private string GenerateKey(Game game)
	{
		string output = "";

		// Conver to byte operators
		output += ConvertTo8BitBinary(game.Environment.Disaster.Id);
		output += ConvertTo8BitBinary(game.Environment.Shelter.Id);

		// Рефлексия?
		for (int i = 0; i < game.Users.Count; i++)
		{

			output += ConvertTo8BitBinary(game.Users[i].SpecialCondition.Id);
			output += ConvertTo8BitBinary(game.Users[i].Profession.Id);
			output += ConvertTo8BitBinary(game.Users[i].Luggage.Id);
			output += ConvertTo8BitBinary(game.Users[i].Biology.Id);
			output += ConvertTo8BitBinary(game.Users[i].Hobbie.Id);
			output += ConvertTo8BitBinary(game.Users[i].Health.Id);
			output += ConvertTo8BitBinary(game.Users[i].Fact.Id);
		}

		return cryptographer.Encode(output);
	}

	private static string ConvertTo8BitBinary(int number) =>
		Convert.ToString(number, 2).PadLeft(8, '0');
}
