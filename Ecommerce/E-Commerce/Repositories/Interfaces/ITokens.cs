using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ITokens
    {
        Task<List<Tokens>> GetTokens();
        Task<bool> PostTokens(Tokens tokens);
    }
}
