namespace Object_Oriented_Design
{
    public class ORNode : IADTreeNode
    {
        public IADTreeNode left
        {
            get;
            set;
        }

        public IADTreeNode right
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public ORNode(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }

        public object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ANDNode : IADTreeNode
    {
        public IADTreeNode left
        {
            get;
            set;
        }

        public IADTreeNode right
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public ANDNode(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }

        public object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class LEAFNode : IADTreeNode
    {
        public IADTreeNode left
        {
            get;
            set;
        }

        public IADTreeNode right
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public LEAFNode(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }

        public object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
