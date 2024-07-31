using DataHshing.Models;
using System.Security.Cryptography;
using System.Text;

namespace DataHshing.Services
{
    public class HashingDataRepository:IHashingDataRepository
    {
        HashAlgorithm algorithm;
        const int KeySize = 32;
        const int Iterations = 350000;
        public async Task<PasswordHash> HashDataWithoutSaltAsync(PasswordHash model)
        {
            if (model is not null)
            {
                    algorithm = SHA512.Create(); // Create SHA512 Algorithm Hashing
                    string Data = model.Password; // Store input 
                    var inputHashingData = Encoding.UTF8.GetBytes(Data); // Encode Input to Bytes
                    var HashInput = algorithm.ComputeHash(inputHashingData); // GenerateHash Pass to Input
                    var HashString = Convert.ToBase64String(HashInput).Replace("-", ""); // Convert Result To String 
                    model.Password = HashString;
                    return model; // return Result
            }
            return new PasswordHash();
        }

        public async Task<PasswordHash> HashDataWithSaltAsync(PasswordHash model)
        {
            if (model is not null)
            {
                var hashAlgorithm = HashAlgorithmName.SHA512; //  Choosing Algorithm Target we use "SHA512" Algorithm
                var Salt = RandomNumberGenerator.GetBytes(KeySize); // Generate Random Numbers array of bytes 32 bit
                var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(model.Password), Salt,
                                                      Iterations, hashAlgorithm , KeySize); // using Pbkdf2 Method to Generate Hashing Password
                var HashConverter = Convert.ToBase64String(hash).Replace("=","*"); // Store Result
                model.Password = HashConverter;
                return model; // return Result
            }
            return new PasswordHash();
        }
    }
}
