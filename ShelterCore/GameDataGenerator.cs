using ShelterCore.Cryptography;
using ShelterCore.Data;

namespace ShelterCore;

public class GameDataConverter
{
	private readonly ICryptography rle;
	private readonly ICryptography bwt;

	public GameDataConverter() : this(new RLE(), new BWT()) { }

	public GameDataConverter(ICryptography rle, ICryptography bwt)
	{
		this.rle = rle;
		this.bwt = bwt;
	}

	public GameData Convert(string key) => Generate(DecodeKey(key));

	private GameData Generate(string key)
	{
		List<int> indexes = Split(key, 8).
			Select(binKey => System.Convert.ToInt32(binKey, 10)).
			ToList();

		using ShelterContext sc = new();

		WorldData worldDatas = new(
			sc.Shelters.ToList()[indexes[0]],
			sc.Disasters.ToList()[indexes[1]]);

		int playersCount = (indexes.Count - 2) / 7;
		List<UserData> userDatas = new(playersCount);

		for (int i = 0, j = 2; i < playersCount; i++)
		{
			userDatas.Add(new UserData(
				i,
				sc.Luggage.ToList()[indexes[j++]],
				sc.Biology.ToList()[indexes[j++]],
				sc.Health.ToList()[indexes[j++]],
				sc.Professions.ToList()[indexes[j++]],
				sc.Facts.ToList()[indexes[j++]],
				sc.Hobbies.ToList()[indexes[j++]],
				sc.SpecialConditions.ToList()[indexes[j++]]));
		}

		sc.Dispose();

		return new(worldDatas, userDatas);
	}

	private string DecodeKey(string key) => bwt.Decode(rle.Decode(key));

	private IEnumerable<string> Split(string str, int chunkSize)
	{
		int chunkCount = str.Length / chunkSize;

		for (int i = 0; i < chunkCount; i++)
			yield return str.Substring(i * chunkSize, chunkSize);
	}
}
