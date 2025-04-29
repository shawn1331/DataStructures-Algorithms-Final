namespace Logic;
public class ChallengeBST
{
    public BSTNode? Root { get; private set; }

    public ChallengeBST() { Root = null; }

    public void AddNode(int id, Challenge challenge, int difficulty)
    {
        Root = AddNode(Root, id, challenge, difficulty);
    }

    private BSTNode? AddNode(BSTNode? node, int id, Challenge challenge, int difficulty)
    {
        if (node is null)
            return new BSTNode(id, challenge, difficulty);
        else if (id > node.ID)
            node.Right = AddNode(node.Right, id, challenge, difficulty);
        else if (id < node.ID)
            node.Left = AddNode(node.Left, id, challenge, difficulty);

        node = RotateTree(node);
        return node;
    }

    public void DeleteNode(int id)
    {
        Root = Delete(Root, id);
    }

    private BSTNode? Delete(BSTNode? node, int id)
    {
        if (node is null)
            return null;
        else if (id > node.ID)
            node.Right = Delete(node.Right, id);
        else if (id < node.ID)
            node.Left = Delete(node.Left, id);
        else
        {
            if (node.Left == null && node.Right == null)
                return null;
            else if (node.Left == null && node.Right != null)
                return node.Right;
            else if (node.Left != null && node.Right == null)
                return node.Left;
            else
            {
                BSTNode? successor = GetSuccessor(node);
                node.ID = successor.ID;
                node.ChallengeForNode = successor.ChallengeForNode;
                node.Difficulty = successor.Difficulty;
                node.Right = Delete(node.Right, successor.ID);
            }
        }

        node = RotateTree(node);
        return node;
    }

    private BSTNode? GetSuccessor(BSTNode? node)
    {
        if (node?.Right != null)
            node = node.Right;

        while (node?.Left != null)
            node = node.Left;

        return node;
    }

    public int GetHeight()
    {
        return height(Root);
    }

    private int height(BSTNode? node)
    {
        int leftHeight = height(node?.Left);
        int rightHeight = height(node?.Right);

        return (1 + Math.Max(leftHeight, rightHeight));
    }

    private BSTNode RotateLeft(BSTNode? node)
    {
        BSTNode temp = node?.Right;
        node.Right = temp?.Left;
        temp.Left = node;
        return temp;
    }

    private BSTNode? RotateRight(BSTNode? node)
    {
        BSTNode? temp = node?.Left;
        node.Left = temp?.Right;
        temp.Right = node;
        return temp;
    }

    public BSTNode? RotateTree(BSTNode? node)
    {
        if (node == null)
        {
            return null;
        }

        int balanceFactor = height(node.Left) - height(node.Right);

        if (balanceFactor > 1)
        {
            if (height(node.Left?.Left) >= height(node.Left?.Right))
            {
                return RotateRight(node);
            }
            else
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

        }
        else if (balanceFactor < -1)
        {
            if (height(node.Right?.Right) >= height(node.Right?.Left))
            {
                return RotateLeft(node);
            }
            else
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
        }
        return node;
    }

    public BSTNode? GetChallenge(int id)
    {
       BSTNode? node = Root;
        while (node?.ID != id)
        {
            if (node == null)
                return null;
            else if (id > node.ID)
                node = node.Right;
            else if (id < node.ID)
                node = node.Left;
            else
                return node;
        }
        return null;
    }
}