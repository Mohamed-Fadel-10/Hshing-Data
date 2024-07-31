using DataHshing.Models;

namespace DataHshing.Services
{
    public interface IHashingDataRepository
    {
        Task<PasswordHash> HashDataWithoutSaltAsync(PasswordHash model);
        Task<PasswordHash> HashDataWithSaltAsync(PasswordHash model);
    }
}
