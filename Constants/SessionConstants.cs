namespace TicketFinder.Constants;

public static class SessionConstants
{
    public static string SessionKey(string ip) => $"s_{ip}";
    public static string DefaultFilterKey => $"df_data";
    public static string ClientIpKey => $"c_ip";
}
