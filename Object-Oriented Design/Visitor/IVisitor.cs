namespace Object_Oriented_Design
{
    public interface IVisitor
    {
        object Visit(ORNode ORNode);
        object Visit(ANDNode ANDNode);
        object Visit(LEAFNode LEAFNode);
    }
}