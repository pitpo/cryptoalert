using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.Authentication.Wrappers
{
    public class JWTWrapper : IJWTWrapper
    {
        private readonly string _secret;

        public JWTWrapper(string secret)
        {
            _secret = secret;
        }

        public string CreateToken(string email)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds())
                .AddClaim("usr", email)
                .Build();
        }

        public string VerifyToken(string token)
        {
            try
            {
                return new JwtBuilder()
                    .WithSecret(_secret)
                    .MustVerifySignature()
                    .Decode(token);
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
