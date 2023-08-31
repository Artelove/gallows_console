namespace gallows_console;

public class Letter
{
    public char Character { get;  private set; }
    public bool IsOpened = false;

    public Letter(char character)
    {
        Character = character;
    }

    public override string ToString()
    {
        if (IsOpened)
            return Character.ToString();
        return "*";
    }
}