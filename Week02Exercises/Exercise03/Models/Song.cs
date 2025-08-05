namespace Ct.Ai.Models

{

public class Song
{
    public string Title { get; set; }
    public int Duration { get; set; }

    public override string ToString()
    {
        return $" {Title}, {Duration}";
    }
}

}