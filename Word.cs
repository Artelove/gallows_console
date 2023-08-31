namespace gallows_console;

public class Word
{
    public int Lenght { get; private set; }
    private readonly List<Letter> _word;

    public Word(string word)
    {
        _word = new List<Letter>();
        foreach (char ch in word)
        {
            _word.Add(new Letter(ch));
        }
        Lenght = _word.Count;
    }

    public bool IsWordCompletelyOpen()
    {
        foreach (var letter in _word)
        {
            if (letter.IsOpened == false)
                return false;
        }

        return true;
    }

    public bool OpenLetter(Letter letter)
    {
        bool someOpened = false;
        foreach (Letter _letter in _word)
        {
            if (letter.Character == _letter.Character)
            {
                _letter.IsOpened = true;
                someOpened = true;
            }

        }

        return someOpened;
    }

    public string GetCurrentWordString()
    {
        string str = "";
        foreach (Letter letter in _word)
        {
            str += letter;
        }

        return str;
    }

    public string GetFullWord()
    {
        string str = "";
        foreach (Letter letter in _word)
        {
            str += letter.Character;
        }
        return str;
    }
}