namespace Perfinko.Infrastructure.Security;

using Meziantou.Framework.Win32;
using Perfinko.Core.Security;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows5.1.2600")]
public class WindowsCredentialStore(string baseKey) : ISecretStore
{
    private readonly string _baseKey = baseKey;

    public void Save(string key, string secret, bool persistant = false)
    {
        CredentialManager.WriteCredential(
            applicationName: $"{_baseKey}.{key}",
            userName: "",
            secret: secret,
            persistence: persistant 
                ? CredentialPersistence.LocalMachine 
                : CredentialPersistence.Session);
    }

    public string? ReadSecret(string key)
    {
        return CredentialManager.ReadCredential(applicationName: $"{_baseKey}.{key}")?.Password;
    }

    public void Delete(string key)
    {
        CredentialManager.DeleteCredential(applicationName: $"{_baseKey}.{key}");
    }
}
