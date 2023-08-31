namespace gallows_console;

public class InputHandler
{
    public readonly string AcceptableCharacters = "abcdefghijklmnopqrstuvwxyz";
    public List<char> Letters;
    private Word _word;
    public delegate void UserGameStep(bool userStepResult);

    public event UserGameStep Step;
    public InputHandler(Word word)
    {
        Letters = new List<char>();
        _word = word;
    }
    public Message HandleUserInputCharacter(string? str)
    {
        if (str == null)
            return new Message(Message.MessageType.ErrorMessage, "Entered void string");
        if (str.Length > 1)
            return new Message(Message.MessageType.ErrorMessage, "You only need to enter one character");
        char letter = str[0];
        if(AcceptableCharacters.Contains(letter) == false)
                return new Message(Message.MessageType.ErrorMessage,
                    $"An unknown character is entered, use only the following set of characters:" +
                    $"\n + {AcceptableCharacters}");
        foreach (var character in Letters)
        {
            if (letter == character)
                return new Message(Message.MessageType.InfoMessage,
                    $"This symbol has been used before");
        }
        Letters.Add(letter);
        if (_word.OpenLetter(new Letter(Letters[^1])))
        {
            Step(true);
            return new Message(Message.MessageType.InfoMessage,
                $"Congratulations, you have discovered a new letter in the word!" +
                $"\n Opened letter: {Letters[^1]}");
        }
        else
        {
            Step(false);
            return new Message(Message.MessageType.InfoMessage,
                $"Unfortunately this letter is not in the word.");
        }
        
    }

    public string GetOpenedLetters()
    {
        string str = "";
        foreach (var ch in Letters)
        {
            str += ch + " ";
        }

        return str;
    }
   
}

public class Message
{
    public enum MessageType
    {
        ErrorMessage,
        InfoMessage
    }
    public string Value { get; private set; }
    public MessageType Type { get; private set; }

    public Message(MessageType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return Type + "\n" + Value;
    }
}