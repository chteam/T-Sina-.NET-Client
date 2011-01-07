namespace CHSNS.Rest.OAuth
{
    using System;

    /// <summary>
    /// Inter face of token.
    /// </summary>
    public interface  IToken
    {
        /// <summary>
        /// token value
        /// </summary>
        String TokenValue
        {
            get;
        }

        /// <summary>
        /// token secret
        /// </summary>
        String TokenSecret
        {
            get;
        }
    }
}
