namespace MRS.Identity.API.Extensions;

public class AppSettings
{
    public string Secret { get; set; }
    public double HoursToExpire { get; set; }
    public string Issuer { get; set; }
    public string ValidAt { get; set; }
}