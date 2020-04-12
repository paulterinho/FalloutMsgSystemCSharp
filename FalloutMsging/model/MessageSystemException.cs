using System;
namespace FalloutMsging.model
{
    public class MessageSystemException : Exception
    {
        public MessageSystemException(String errMsg) : base( errMsg )
        {
           
        }
    }
}
