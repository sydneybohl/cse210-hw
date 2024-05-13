public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        // Split up the words in text and store each as a word object in the list _words
        // Split and then loop through each word
        // Create word object and put it into _words
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }


    }

    public void HideRandomWords(int numberToHide)
    {
        // Set the state of a randomly selected group of words to be hidden 
        // Need to find a set of visible words
        Random random = new Random();
        int wordsToHide = Math.Min(numberToHide, _words.Count(w => !w.IsHidden()));

        for (int i = 0; i < wordsToHide; i++)
        {
            // Generate a random index to hide 
            int index = random.Next(_words.Count);

            while (_words[index].IsHidden())
            {
                index = random.Next(_words.Count);
            }

            // Hide the word at the selected index
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        // Reference, All the words
        string displayText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}