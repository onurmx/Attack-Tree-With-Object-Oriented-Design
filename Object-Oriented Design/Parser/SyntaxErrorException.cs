using System;

namespace Object_Oriented_Design
{
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException() : base("SYNTAX_ERROR")
        {

        }
    }
}