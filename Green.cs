using System;

public abstract class Green
{
    private string _input;

    public string Input => _input;

    protected Green(string input)
    {
        _input = input ?? throw new ArgumentNullException(nameof(input));
    }

    public abstract void Review();
    public abstract object Output { get; }
}