namespace STS.Common.Cryptography.Services
{
    public interface IEncryptorService
    {
        string EncryptUserData(string login, string password);
    }
}