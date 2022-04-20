namespace StaticGame.Cryptography;

public class Cryptographer : ICryptography
{
	private readonly ICryptography rle;
	private readonly ICryptography bwt;

	public Cryptographer() : this(new RLE(), new BWT()) { }

	public Cryptographer(ICryptography rle, ICryptography bwt)
	{
		this.rle = rle;
		this.bwt = bwt;
	}

	public string Decode(string str)
		=> bwt.Decode(rle.Decode(str));

	public string Encode(string str)
		=> rle.Encode(bwt.Encode(str));
}

