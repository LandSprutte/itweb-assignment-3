using System;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace assignment3_db.Services
{
    public class AuthenticationService: IValidationService
    {

        private readonly JsonWebTokenHandler _jwt;
        private readonly SymmetricSecurityKey _key;
        private readonly SigningCredentials _credentials;
        private readonly TokenValidationParameters _validationParameters;

        public AuthenticationService()
        {
            this._jwt = new JsonWebTokenHandler();
            this._key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("My vevvy secret key"));
            this._validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("My vevvy secret key"))
            };
            this._credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        }
        public string SignToken(object data)
        {
            var token = _jwt.CreateToken(JsonConvert.SerializeObject(data), _credentials);

            return token;

        }

        public bool VerifyToken(string token)
        {
            try
            {
                _jwt.ValidateToken(token, _validationParameters);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            

        }
    }
}