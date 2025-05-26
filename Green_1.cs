using System;

public class Green1 : Green
{
    private (char Letter, double Frequency)[] _output = Array.Empty<(char, double)>();

    public Green1(string input) : base(input)
    {
    }

    public override void Review()
    {
        int[] counts = new int[32];
        int totalLetters = 0;

        for (int i = 0; i < Input.Length; i++)
        {
            char c = char.ToLower(Input[i]);
            if (c >= 'а' && c <= 'я')
            {
                int index = c - 'а';
                counts[index]++;
                totalLetters++;
            }
            else if (c == 'ё')
            {
                counts[31]++;
                totalLetters++;
            }
        }

        var result = new (char Letter, double Frequency)[32];

        for (int i = 0; i < 31; i++)
        {
            if (counts[i] > 0)
            {
                char letter = (char)('а' + i);
                double freq = Math.Round((double)counts[i] / totalLetters, 4);
                result[i] = (letter, freq);
            }
        }

        if (counts[31] > 0)
        {
            result[31] = ('ё', Math.Round((double)counts[31] / totalLetters, 4));
        }

        _output = result;
    }

    public override object Output => _output;

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < _output.Length; i++)
        {
            var (Letter, Frequency) = _output[i];
            if (Frequency > 0)
                result += $"{Letter} - {Frequency:F4}\n";
        }

        return result.TrimEnd('\n');
    }
}