using System;

namespace Object_Oriented_Design
{
    public class EvaluateSuccessVisitor : IVisitor
    {
        public bool GetValue(IADTreeNode treenode, EvaluateSuccessVisitor esv, ADTreeContext con)
        {
            if (treenode.left == null && treenode.right == null)
            {
                var random = new Random();
                bool randomBool = random.Next(2) == 1;
                bool? output = con.GetNodeOutcome((string)treenode.Accept(esv));
                return (output == null) ? randomBool : output.Value;
            }
            bool firstNode = GetValue(treenode.left, esv, con);
            bool secondNode = GetValue(treenode.right, esv, con);
            if (treenode is ORNode)
            {
                return firstNode || secondNode;
            }
            else
            {
                return firstNode && secondNode;
            }
        }

        public object Visit(LEAFNode Leaf)
        {
            return Leaf.Name;
        }

        public object Visit(ORNode OrNode)
        {
            return null;
        }

        public object Visit(ANDNode AndNode)
        {
            return null;
        }
    }

    public class EvaluateCostVisitor : IVisitor
    {
        public int GetValue(IADTreeNode treenode, EvaluateCostVisitor ecv, ADTreeContext con)
        {
            if (treenode is ORNode)
            {
                int first = GetValue(treenode.left, ecv, con);
                int second = GetValue(treenode.right, ecv, con);
                return first < second ? first : second;
            }
            else if (treenode is ANDNode)
            {
                int firstNode = GetValue(treenode.left, ecv, con);
                int secondNode = GetValue(treenode.right, ecv, con);
                return secondNode + firstNode;
            }
            else
            {
                return (int)treenode.Accept(this);
            }
        }

        public object Visit(LEAFNode LeafNode)
        {
            return LeafNode.Cost;
        }

        public object Visit(ORNode OrNode)
        {
            return OrNode.Cost;
        }

        public object Visit(ANDNode AndNode)
        {
            return AndNode.Cost;
        }
    }

    public class EvaluateDurationVisitor : IVisitor
    {
        public int GetValue(IADTreeNode treenode, EvaluateDurationVisitor edv, ADTreeContext con)
        {
            if (treenode is ORNode)
            {
                int first = GetValue(treenode.left, edv, con);
                int second = GetValue(treenode.right, edv, con);
                return first < second ? first : second;
            }
            else if (treenode is ANDNode)
            {
                int first = GetValue(treenode.left, edv, con);
                int second = GetValue(treenode.right, edv, con);
                return second + first;
            }
            else
            {
                return (int)treenode.Accept(this);
            }
        }

        public object Visit(ANDNode AndNode)
        {
            return AndNode.Duration;
        }

        public object Visit(LEAFNode LeafNode)
        {
            return LeafNode.Duration;
        }

        public object Visit(ORNode OrNode)
        {
            return OrNode.Duration;
        }
    }
}