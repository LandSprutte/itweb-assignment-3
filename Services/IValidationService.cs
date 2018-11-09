using System;

namespace assignment3_db.Services
{
    public interface IValidationService
    {
        string SignToken(object data);
        bool VerifyToken(string token);
    }
}