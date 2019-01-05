using CryptoAlertCore.Models;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System;

namespace CryptoAlertCore.Authentication.Wrappers
{
    public class JWTWrapper : IJWTWrapper
    {
        private readonly string _secret;

        public JWTWrapper(string secret)
        {
            _secret = secret;
        }

        public Token CreateToken(string email)
        {
            return new Token(new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds())
                .AddClaim("usr", email)
                .Build());
        }

        public string GetDecodedToken(Token token)
        {
            try
            {
                return new JwtBuilder()
                    .WithSecret(_secret)
                    .MustVerifySignature()
                    .Decode(token.Content);
            }
            catch (TokenExpiredException)
            {
                throw;
            }
            catch (SignatureVerificationException)
            {
                throw;
            }
        }
    }
}
