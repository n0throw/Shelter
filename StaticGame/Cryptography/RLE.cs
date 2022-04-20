namespace StaticGame.Cryptography;

public class RLE : ICryptography
{
    public string Decode(string str)
    {
        string output = "";
        string number = "";

        str.ToList().ForEach(character =>
        {
            if (char.IsDigit(character))
                number += character;
            else
            {
                output += new string(character, int.Parse(number));
                number = "";
            }
        });

        return output;
    }

    public string Encode(string str)
    {
        string output = "";
        int count = 0;
        char currentCharacter = str[0];

        str.ToList().ForEach(character =>
        {
            if (character == currentCharacter)
                count++;
            else
            {
                output += $"{count}{currentCharacter}";
                currentCharacter = character;
                count = 1;
            }
        });

        return output += $"{count}{currentCharacter}";
    }
}