using ShelterCore.Cryptography;
using ShelterCore.Data;

namespace ShelterCore;

public class KeyGenerator
{
	private const int minPlayersCount = 6;
	private const int maxPlayersCount = 16;

	private GameData gameData;
	private int? playersCount;

	private readonly ICryptography rle;
	private readonly ICryptography bwt;

	public KeyGenerator() : this(new RLE(), new BWT()) { }

	public KeyGenerator(ICryptography rle, ICryptography bwt)
	{
		this.rle = rle;
		this.bwt = bwt;
	}

	public string Generate(int playersCount)
	{
		this.playersCount = null;

		if (playersCount < minPlayersCount)
		{
			throw new ArgumentOutOfRangeException(
				nameof(playersCount),
				"6-16",
				$"The number of players must be more than {minPlayersCount}"
			);
		}
		if (playersCount > maxPlayersCount)
		{
			throw new ArgumentOutOfRangeException(
				nameof(playersCount),
				"6-16",
				$"The number of players must be less than {maxPlayersCount}"
			);
		}

		this.playersCount = playersCount;

		GetData();

		return GenerateKey();
	}

	// Для теста, убрать потом
	public string Generate(GameData gameData)
	{
		playersCount = gameData.UsersData.Count;

		if (playersCount < minPlayersCount)
		{
			throw new ArgumentOutOfRangeException(
				nameof(gameData.UsersData.Count),
				"6-16",
				$"The number of players must be more than {minPlayersCount}"
			);
		}
		if (playersCount > maxPlayersCount)
		{
			throw new ArgumentOutOfRangeException(
				nameof(gameData.UsersData.Count),
				"6-16",
				$"The number of players must be less than {maxPlayersCount}"
			);
		}

		this.gameData = gameData;

		return GenerateKey();
	}

	private void GetData()
	{
		using ShelterContext bc = new();

		WorldData worldData;
		List<UserData> usersData = new(playersCount.Value);


		// рефлексия?
		List<SpecialConditionData> specialCondition = bc.
			GetShuffleData<SpecialConditionData>().
			GetRange(0, playersCount.Value);

		List<ProfessionData> profession = bc.
			GetShuffleData<ProfessionData>().
			GetRange(0, playersCount.Value);

		List<LuggageData> luggage = bc.
			GetShuffleData<LuggageData>().
			GetRange(0, playersCount.Value);

		List<BiologyData> biology = bc.
			GetShuffleData<BiologyData>().
			GetRange(0, playersCount.Value);

		List<HobbieData> hobbie = bc.
			GetShuffleData<HobbieData>().
			GetRange(0, playersCount.Value);

		List<HealthData> health = bc.
			GetShuffleData<HealthData>().
			GetRange(0, playersCount.Value);

		List<FactData> fact = bc.
			GetShuffleData<FactData>().
			GetRange(0, playersCount.Value);


		worldData = new(
			bc.GetShuffleData<ShelterData>().First(),
			bc.GetShuffleData<DisasterData>().First()
		);

		for (int id = 1; id <= playersCount.Value; id++)
		{
			usersData.Add(new()
			{
				Id = id,
				Luggage = luggage[id - 1],
				Biology = biology[id - 1],
				Health = health[id - 1],
				Profession = profession[id - 1],
				Facts = fact[id - 1],
				Hobbies = hobbie[id - 1],
				SpecialConditions = specialCondition[id - 1]
			});
		}

		gameData = new(worldData, usersData);

		bc.Dispose();
	}

	/* Block key
     * one block - 8 bit (128 value)
     * 1. Bunker
     * 2. Disaster
     *
     * Next blocks playes data
     *
     * 3. Luggage
     * 4. Biology
     * 5. Health
     * 6. Profession
     * 7. Facts
     * 8. Hobbies
     * 9. SpecialConditions
     *
     * 10. Luggage playes 2
     * 11. etc...
     */
	private string GenerateKey()
	{
		string output = "";

		// Conver to byte operators
		output += ConvertTo8BitBinary(gameData.WorldData.Shelter.Id);
		output += ConvertTo8BitBinary(gameData.WorldData.Disaster.Id);

		// Рефлексия?
		for (int i = 0; i < playersCount; i++)
		{
			output += ConvertTo8BitBinary(gameData.UsersData[i].Luggage.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].Biology.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].Health.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].Profession.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].Facts.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].Hobbies.Id);
			output += ConvertTo8BitBinary(gameData.UsersData[i].SpecialConditions.Id);
		}

		return rle.Encode(bwt.Encode(output));
	}

	private static string ConvertTo8BitBinary(int number) =>
		Convert.ToString(number, 2).PadLeft(8, '0');

}
