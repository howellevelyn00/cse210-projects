namespace FinalProject
{
    public class VocabEntry
{
    private string word;
    private string definition;
    
    public VocabEntry(string word, string definition)
    {
        this.word = word;
        this.definition = definition;
    }

    public string GetWord()
    {
        return word;
    }

    public string GetDefinition()
    {
        return definition;
    }

    public void SetDefinition(string definition)
    {
        this.definition = definition;
    }
}
}