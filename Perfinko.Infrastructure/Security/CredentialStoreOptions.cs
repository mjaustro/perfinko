namespace Perfinko.Infrastructure.Security;

public class CredentialStoreOptions
{
    public string ApplicationName { get; set; } = "";
    public string Service { get; set; } = "";
    public string Environment { get; set; } = "";

    public string Namespace =>
        $"{ApplicationName}.{Service}.{Environment}";
}
