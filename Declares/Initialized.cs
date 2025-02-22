using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.ApplicationFrameworks;
using System.Data.Entity.Core.Metadata.Edm;
using static System.Net.WebRequestMethods;
using static DeliveryTakeOrder.Configurations;

namespace DeliveryTakeOrder.Declares
{
    internal class Initialized
    {
        // Constants
        public static string R_KeyPassword = "";
        public static Image R_Logo = DeliveryTakeOrder.Properties.Resources.Logo;
        public static long R_CompanyCode = 10001L;
        public static string R_CompanyName;
        public static string R_CompanyAddress;
        public static string R_CompanyVATNumber;
        public static string R_FullCompanyName;
        public static string R_FullCompanyAddress;
        public static string R_FullCompanyAddress_No_VAT;
        public static string R_CompanyKhmerName;
        public static string R_CompanyKhmAddress;
        public static string R_CompanyVATTin;
        public static string R_CompanyTelephone;

        public static string R_PrefixDatabase = "DB";
        public static string R_PublicIPAddress;
        public static string R_IPAddress = "192.168.1.111";
        public static string R_IPAddress_Temp = "192.168.100.49";
        public static string R_UserConnection = "UserConnection";
        public static string R_PasswordConnection = "123";
        public static string R_DatabaseName;
        public static string R_MainDatabaseName = "";
        public static string R_PortConnection;
        public static bool vIsNestleOnly = false;

        public static bool R_CorrectPassword;
        public static string R_PermissionPassword;
        public static bool R_IsCancel;
        public static bool R_SearchCustomerId;
        public static string R_SearchValue;
        public static bool R_AllUnpaid;
        public static DateTime R_DateFrom;
        public static DateTime R_DateTo;
        public static string R_IndexString;
        public static double R_SelectedAmount;
        public static bool R_IsFullPayment;
        public static string R_CollectorName;
        public static double R_SpecialOfferAmount;
        public static string R_Barcode;
        public static string R_StampNumberSelected;
        public static string R_MessageAlert;
        public static string R_DocumentNumber;
        public static string R_LineCode;
        public static string R_DeptCode;

        // Server Constants
        public const string url_ = "http://206.189.154.158:55411"; // Server Production
        public const string username_ = "untadmin";
        public const string password_ = "tnac89";
        public const string login_ = "/User/login";

        // Enum
        public enum ViewJournalReport
        {
            All_Journal,
            All_Journal_Completed,
            All_Journal_Not_Completed
        }
        public static ViewJournalReport R_JournalSelected;

        // Private DataTable to store company data
        private static DataTable DTable;

        // Method to check if company exists
        public static bool CheckCompaniesExistOrNot(DatabaseFramework Data, ApplicationFramework App)
        {
            bool RExisted = false;
            var Dic = new Dictionary<string, object> { { "CompanyCode", R_CompanyCode } };
            Data.DatabaseName = "CompanySetup";

            DTable = (DataTable)Data.Selects("Companies", null, Dic, false, 0, null, null, GetConnectionType(Data, App));
            if (DTable != null && DTable.Rows.Count > 0)
            {
                R_CompanyKhmerName = DTable.Rows[0]["ComKhmerName"]?.ToString().Trim() ?? "";
                R_CompanyName = DTable.Rows[0]["ComName"]?.ToString().Trim().ToUpper().Replace("&", "&&").Replace("'S", "'s") ?? "";
                R_CompanyAddress = DTable.Rows[0]["ComAddress"]?.ToString().Trim() ?? "";
                R_CompanyTelephone = DTable.Rows[0]["ComTelephone"]?.ToString().Trim() ?? "";
                R_CompanyKhmAddress = DTable.Rows[0]["ComKhmerAddress"]?.ToString().Trim() ?? "";
                R_CompanyVATTin = DTable.Rows[0]["ComVATNumber"]?.ToString().Trim() ?? "";

                // Full company info
                R_FullCompanyName = R_CompanyKhmerName + Environment.NewLine + R_CompanyName;
                R_FullCompanyAddress = $"លេខអត្តសញ្ញាណកម្ម អតប (VAT TIN)៖ {R_CompanyVATTin}\n" +
                                       $"អាសយដ្ឋាន៖ {R_CompanyKhmAddress}\n" +
                                       $"Address៖ {R_CompanyAddress}\n" +
                                       $"Telephone Nº៖ {R_CompanyTelephone}";

                R_FullCompanyAddress_No_VAT = $"អាសយដ្ឋាន៖ {R_CompanyKhmAddress}\n" +
                                              $"Address៖ {R_CompanyAddress}\n" +
                                              $"Telephone Nº៖ {R_CompanyTelephone}";
                RExisted = true;
            }
            else
            {
                R_CompanyKhmerName = "";
                R_CompanyName = "";
                R_CompanyAddress = "";
                R_FullCompanyAddress_No_VAT = "";
                R_CompanyVATTin = "";
                R_CompanyTelephone = "";
                RExisted = false;
            }

            R_DatabaseName = R_CompanyName;
            Data.DatabaseName = App.MergeObject(R_CompanyName);
            return RExisted;
        }

        // Method to get connection type
        public static ConnectionType GetConnectionType(DatabaseFramework Data, ApplicationFramework App)
        {
            if (App.CheckConnectionByPing(Data.PublicIPAddress))
            {
                return ConnectionType.INTERNET;
            }
            else
            {
                if (!App.CheckConnectionByPing(Data.IPAddress))
                {
                    Data.IPAddress = App.CheckConnectionByPing(R_IPAddress_Temp) ? R_IPAddress_Temp : R_IPAddress;
                }
                return ConnectionType.NETWORK;
            }
        }

        // Method to initialize settings
        public static void LoadingInitialized(DatabaseFramework Data, ApplicationFramework App)
        {
            Data.PrefixDatabase = R_PrefixDatabase;
            Data.PublicIPAddress = R_PublicIPAddress;
            Data.IPAddress = R_IPAddress;
            Data.UserConnection = R_UserConnection;
            Data.Password = R_PasswordConnection;
            Data.DatabaseName = App.MergeObject(R_CompanyName);
            Data.PortNumber = R_PortConnection;
        }
    }
}
