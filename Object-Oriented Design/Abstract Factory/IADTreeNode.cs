namespace Object_Oriented_Design
{
    public interface IADTreeNode
    {
        string Name { get; set; }
        int Duration { get; set; }
        int Cost { get; set; }
        IADTreeNode left { get; set; }
        IADTreeNode right { get; set; }
        object Accept(IVisitor visitor);
    }
}