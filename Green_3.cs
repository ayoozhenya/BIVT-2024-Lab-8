using System;

public class Green3 : Green
{
    private string[] _output = Array.Empty<string>();
    private string _substring;

    public Green3(string input, string substring) : base(input)
    {
        _substring = substring?.ToLower() ?? throw new ArgumentNullException(nameof(substring));
    }

    public override void Review()
    {
        var words = ExtractWords();
        var result = new string[words.Length];
        int count = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (ContainsIgnoreCase(words[i], _substring))
            {
                result[count++] = words[i];
            }
        }

        Array.Resize(ref result, count);
        _output = result;
    }

    private string[] ExtractWords()
    {
        var words = new string[Input.Length / 2];
        int wordStart = -1;
        int count = 0;

        for (int i = 0; i <= Input.Length; i++)
        {
            char c = i < Input.Length ? char.ToLower(Input[i]) : '\0';
            bool isLetterOrHyphen = (c >= 'a' && c <= 'z') ||
                                    (c >= 'а' && c <= 'я') ||
                                    c == 'ё' || c == '-' || c == '\'';

            if (wordStart == -1 && isLetterOrHyphen)
            {
                wordStart = i;
            }
            else if (wordStart != -1 && !isLetterOrHyphen)
            {
                words[count++] = Input.Substring(wordStart, i - wordStart);
                wordStart = -1;
            }
        }

        var result = new string[count];
        Array.Copy(words, result, count);
        return result;
    }

    private bool ContainsIgnoreCase(string text, string sub)
    {
        for (int i = 0; i <= text.Length - sub.Length; i++)
        {
            bool match = true;
            for (int j = 0; j < sub.Length; j++)
            {
                if (char.ToLower(text[i + j]) != sub[j])
                {
                    match = false;
                    break;
                }
            }
            if (match) return true;
        }
        return false;
    }

    public override object Output => _output;

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < _output.Length; i++)
            result += _output[i] + "\n";

        return result.TrimEnd('\n');
    }
}