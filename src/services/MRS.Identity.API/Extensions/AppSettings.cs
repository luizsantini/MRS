namespace MRS.Identity.API.Extensions;

public class AppSettings
{
    public string Secret { get; set; }
    public string ExpireAt { get; set; }
    public string Issuer { get; set; }
    public string ValidAt { get; set; }
}