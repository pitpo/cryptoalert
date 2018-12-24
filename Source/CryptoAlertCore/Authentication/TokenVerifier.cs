using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Parsers;
using JWT;

namespace CryptoAlertCore.Authentication
{
    public class TokenVerifier : ITokenVerifier
    {
        private readonly IJWTWrapper _jwtWrapper;
        private readonly IParser _parser;

        public TokenVerifier(IJWTWrapper jwtWrapper, IParser parser)
        {
            _jwtWrapper = jwtWrapper;
            _parser = parser;
        }

        public (bool verified, string status) VerifyToken(string token)
        {
            try
            {
                string tokenJson = _jwtWrapper.GetDecodedToken(token);
                dynamic tokenDeserialized = _parser.Parse<dynamic>(tokenJson);
                return (verified: true, status: tokenDeserialized["usr"].Value);
            }
            catch (TokenExpiredException)
            {
                return (verified: false, status: "Token has expired");
            }
            catch (SignatureVerificationException)
            {
                return (verified: false, status: "Token has invalid signature");
            }
        }
    }
}
