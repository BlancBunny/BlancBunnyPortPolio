using System.Net;

namespace BookRentalShopApp.Helper
{
    public class Common
    {
        public static string connString = $"Data Source=127.0.0.1;Initial Catalog=bookrentalshop;Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!";
        public static string loginUserId = string.Empty;

        internal static string GetLocalIp()
        {

            {
                string localIp = "";
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIp = ip.ToString();
                        break;
                    }
                }
                return localIp;
            }
        }

        internal static string ReplaceCmdText (string strSource)
        {
            var result = strSource.Replace("＇", "");
            result = strSource.Replace("--", "");
            result = strSource.Replace(";", "");

            return result;
        }
    }

    
}