namespace Logic;
public class BSTNode
{
    public BSTNode? Left { get;  set; }
    public BSTNode? Right { get;  set; }
    public int ID { get; set; }
    public int Difficulty { get; set; }
    public Challenge ChallengeForNode { get; set; }

    public BSTNode(int id, Challenge challenge, int difficulty) {  ID = id; ChallengeForNode = challenge; Difficulty = difficulty; }
}