using Newtonsoft.Json;

namespace StaticGame.Data;

public record struct Game(Environment Environment, List<User> Users)
{
	public string ToJSON()
		=> JsonConvert.SerializeObject(this);
}

