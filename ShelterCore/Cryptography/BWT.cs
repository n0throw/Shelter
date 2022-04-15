namespace ShelterCore.Cryptography;

/* Не оптимально работает
 * Результат вида:
 * 114B 684A 1C 114A (Разделители для удобства восприятия)
 * Должен быть:
 * 114B 798A 1C
*/
public class BWT : ICryptography
{
    public string Encode(string str)
    {
        str = str.Replace('0', 'A').Replace('1', 'B') + 'C';
        string output = "";

        List<string> shifts = new(str.Length);
        shifts.Add(str);

        for (int i = 0; i < str.Length - 1; i++)
            shifts.Add(Shift(shifts[i]));

        shifts.Sort();

        shifts.ForEach(shift => output += shift[^1]);

        return output;
    }

    public string Decode(string str)
    {
        List<string> outputList = new(str.Length);

        for (int i = 0; i < str.Length; i++)
            outputList.Add("");

        for (int i = 0; i < str.Length; i++)
        {
            for (int j = 0; j < str.Length; j++)
                outputList[j] = str[j] + outputList[j];

            outputList.Sort();
        }

        return outputList.Where(x => x[^1] == 'C').First().Replace('A', '0').Replace('B', '1').TrimEnd('C');
    }

    private static string Shift(string word)
    {
        string output = word;
        return output.Remove(0, 1) + word[0];
    }
}
