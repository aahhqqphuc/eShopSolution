using System;

namespace EShopSolution.Utilities.Exceptions
{
    public class EShopException : Exception
    {
        public EShopException()
        {
        }

        public EShopException(string message)
            : base(message)
        {
        }

        public EShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
