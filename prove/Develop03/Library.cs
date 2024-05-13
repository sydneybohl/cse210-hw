public class Library
{
    private List<Scripture> _scriptures;

    public Library()
    {
        // Initialize the library with scriptures
        _scriptures = new List<Scripture>();

        _scriptures.Add(new Scripture(new Reference("Matthew", 11, 29), "Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls."));
        _scriptures.Add(new Scripture(new Reference("John", 14, 27), "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. Let not your heart be troubled, neither let it be afraid."));
        _scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        _scriptures.Add(new Scripture(new Reference("John", 1, 3), "All things were made by him; and without him was not any thing made that was made."));
    }

    // Method to get a random scripture from the library
    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        return _scriptures[random.Next(_scriptures.Count)];
    }
}