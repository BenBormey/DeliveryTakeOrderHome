using Microsoft.VisualBasic;

namespace DeliveryTakeOrder
{

    public abstract class Configuration
    {
        public string PrefixDatabase { get; set; } = "DB";
        public string PrefixTable { get; set; } = "Tbl";
        public string PrefixProcedure { get; set; } = "Pro";
        public string PrefixView { get; set; } = "Vie";
        public string PrefixFunction { get; set; } = "Fun";
    }

    public class Configurations : Configuration
    {
        private DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework App = new DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework();

        private static string Folder = "MAIN_SERVER";
        public static string FolderName
        {
            set
            {
                Folder = value;
            }
            get
            {
                return Folder;
            }
        }

        private static string SelectedDB = "BMS";
        public static string SelectedDatabase
        {
            set
            {
                SelectedDB = value;
            }
            get
            {
                return SelectedDB;
            }
        }

        public string GetComputerName
        {
            get
            {
                return System.Net.Dns.GetHostName();
            }
        }

        private string DefaultIPAddress = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
        public string GetIPAddress
        {
            get
            {
                return DefaultIPAddress;
            }
        }

        private string R_DatabaseName;
        public string DatabaseName
        {
            set
            {
                R_DatabaseName = value;
            }
            get
            {
                return R_DatabaseName;
            }
        }

        private string R_PublicIPAddress;
        public string PublicIPAddress
        {
            set
            {
                R_PublicIPAddress = value;
            }
            get
            {
                return R_PublicIPAddress;
            }
        }

        private string R_IPAddress;
        public string IPAddress
        {
            set
            {
                R_IPAddress = value;
            }
            get
            {
                return R_IPAddress;
            }
        }

        private string R_UserConnection;
        public string UserConnection
        {
            set
            {
                R_UserConnection = value;
            }
            get
            {
                return R_UserConnection;
            }
        }

        private string R_Password;
        public string Password
        {
            set
            {
                R_Password = value;
            }
            get
            {
                return R_Password;
            }
        }

        private string R_PortNumber;
        public string PortNumber
        {
            set
            {
                R_PortNumber = value;
            }
            get
            {
                return R_PortNumber;
            }
        }

        public enum ConnectionType
        {
            INTERNET,
            NETWORK
        }

        public Configurations()
        {
            R_DatabaseName = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.DatabaseName, FolderName);
            R_PublicIPAddress = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.PublicIPAddress, FolderName);
            R_IPAddress = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.IPAddress, FolderName);
            R_UserConnection = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.UserConnection, FolderName);
            R_Password = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.PasswordConnection, FolderName);
            R_PortNumber = App.GetRegistry(DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework.RegistryKeyName.PortNumber, FolderName);
        }
        public string ConnectionString(ConnectionType Type = ConnectionType.NETWORK, bool IsPrefixDatabase = true)
        {
            string R_Connection = "";
            if (Type == ConnectionType.NETWORK)
            {
                if (string.IsNullOrEmpty(Strings.Trim(DatabaseName)))
                {
                    R_Connection = string.Format("Server={0};uid={1};pwd={2};", IPAddress, UserConnection, Password);
                }
                else
                {
                    R_Connection = string.Format("Server={0};Initial Catalog={1};uid={2};pwd={3};", IPAddress, Interaction.IIf(IsPrefixDatabase == true, string.Format("{0}{1}", PrefixDatabase, DatabaseName), DatabaseName), UserConnection, Password);
                }
            }
            else if (string.IsNullOrEmpty(Strings.Trim(DatabaseName)))
            {
                R_Connection = string.Format("Network Library=DBMSSOCN;Data Source={0}{1};uid={2};pwd={3};", PublicIPAddress, Interaction.IIf(string.IsNullOrEmpty(Strings.Trim(PortNumber)), "", "," + PortNumber), UserConnection, Password);
            }
            else
            {
                R_Connection = string.Format("Network Library=DBMSSOCN;Data Source={0}{1};Initial Catalog={2};uid={3};pwd={4};", PublicIPAddress, Interaction.IIf(string.IsNullOrEmpty(Strings.Trim(PortNumber)), "", "," + PortNumber), Interaction.IIf(IsPrefixDatabase == true, string.Format("{0}{1}", PrefixDatabase, DatabaseName), DatabaseName), UserConnection, Password);
            }
            return R_Connection;
        }
    }
}