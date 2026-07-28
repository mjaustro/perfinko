namespace Perfinko.Core.Security;

public interface ISecretStore
{
    void Save(string key, string secret, bool persistant = false);

    string? ReadSecret(string key);

    void Delete(string key);
}
