using System;

public class Green2 : Green
{
    private char[] _output = Array.Empty<char>();
    private int[] _counts = new int[32];

    public Green2(string input) : base(input)
    {
    }

    public override void Review()
    {
        bool wordStart = true;
        for (int i = 0; i < Input.Length; i++)
        {
            char c = char.ToLower(Input[i]);

            if (wordStart && ((c >= 'а' && c <= 'я') || c == 'ё'))
            {
                if (c >= 'а' && c <= 'я')
                    _counts[c - 'а']++;
                else if (c == 'ё')
                    _counts[31]++;
                wordStart = false;
            }
            else if (!char.IsWhiteSpace(c) && !IsPunctuation(c))
            {
                wordStart = false;
            }
            else
            {
                wordStart = true;
            }
        }

        char[] letters = new char[32];
        for (int i = 0; i < 31; i++) letters[i] = (char)('а' + i);
        letters[31] = 'ё';

        for (int i = 0; i < 32; i++)
        {
            for (int j = i + 1; j < 32; j++)
            {
                bool swap = false;
                if (_counts[i] < _counts[j]) swap = true;
                else if (_counts[i] == _counts[j] && letters[i] > letters[j]) swap = true;

                if (swap)
                {
                    (letters[i], letters[j]) = (letters[j], letters[i]);
                    (_counts[i], _counts[j]) = (_counts[j], _counts[i]);
                }
            }
        }

        int count = 0;
        for (int i = 0; i < 32; i++) if (_counts[i] > 0) count++;

        char[] res = new char[count];
        int idx = 0;
        for (int i = 0; i < 32; i++)
        {
            if (_counts[i] > 0)
                res[idx++] = letters[i];
        }

        _output = res;
    }

    private bool IsPunctuation(char c)
    {
        char[] punct = {
            '.', '!', '?', ',', ':', '\"', ';', '–', '-', '(', ')',
            '[', ']', '{', '}', '/', '\'', '`', '«', '»'
        };

        for (int i = 0; i < punct.Length; i++)
            if (c == punct[i])
                return true;
        return false;
    }

    public override object Output => _output;

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < _output.Length; i++)
        {
            result += _output[i];
            if (i < _output.Length - 1)
                result += ", ";
        }

        return result;
    }
}