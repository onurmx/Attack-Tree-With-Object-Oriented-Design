using System.Collections.Generic;
using System.Linq;

namespace Object_Oriented_Design
{
    class ADTreeParser
    {
        public IADTreeNode Parse(string prefix_expression)
        {
            Stack<string> tokens = new Stack<string>(prefix_expression.Split(' ').Reverse<string>());
            var expression = ParseNext(tokens);
            if (tokens.Count != 0) throw new SyntaxErrorException();
            return expression;
        }

        private IADTreeNode ParseNext(Stack<string> tokens)
        {
            if (tokens.Count == 0) throw new SyntaxErrorException();
            string[] split = tokens.Pop().Split(',');
            if (split.Length != 4) throw new SyntaxErrorException();
            string type = split[0];
            string name = split[1];
            int cost = int.Parse(split[2]);
            int time = int.Parse(split[3]);
            switch (type)
            {
                case "AND":
                    ANDNode ANDNode = new ANDNode(name, time, cost);
                    ANDNode.left = ParseNext(tokens);
                    ANDNode.right = ParseNext(tokens);
                    return ANDNode;
                case "OR":
                    ORNode ORNode = new ORNode(name, time, cost);
                    ORNode.left = ParseNext(tokens);
                    ORNode.right = ParseNext(tokens);
                    return ORNode;
                case "LEAF":
                    return new LEAFNode(name, time, cost);
                default: throw new SyntaxErrorException();
            }
        }
    }
}